using System.Net;
using System.Net.Http.Headers;
using GigaChatSDK.Exceptions;
using GigaChatSDK.Extensions;
using GigaChatSDK.Requests.Abstractions;
using GigaChatSDK.Types;

namespace GigaChatSDK;

/// <summary>
///     Клиент для работы с API
/// </summary>
/// <param name="options">Конфигурация</param>
/// <param name="httpClient">Экземпляр <see cref="HttpClient" /></param>
public class GigaChatClient(
    GigaChatClientOptions options,
    HttpClient? httpClient = default)
    : IGigaChatClient, IDisposable
{
    private readonly GigaChatClientOptions _clientOptions = options ?? throw new ArgumentNullException(nameof(options));
    private readonly HttpClient _httpClient = httpClient ?? new HttpClient();

    private AccessToken? _accessToken;

    /// <inheritdoc />
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    /// <inheritdoc />
    public async Task<AccessToken?> GetAccessTokenAsync(CancellationToken cancellationToken)
    {
        if (!_clientOptions.AutoRefreshToken || (!string.IsNullOrEmpty(_accessToken?.Value) && DateTime.UtcNow < _accessToken?.ExpiresAt)) 
            return _accessToken;

        var url = $"{GigaChatClientOptions.BaseAccessTokenUrl}/oauth";

        var httpRequest = new HttpRequestMessage(HttpMethod.Post, url)
        {
            Content = new FormUrlEncodedContent(
                [new KeyValuePair<string, string>("scope", _clientOptions.Scope.GetEnumMemberValue())])
        };

        httpRequest.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Basic", _clientOptions.AuthData);
        httpRequest.Headers.Add("RqUID", Guid.NewGuid().ToString());

        using var httpResponse = await SendRequestAsync(
                _httpClient, httpRequest, cancellationToken)
            .ConfigureAwait(false);

        if (httpResponse.StatusCode != HttpStatusCode.OK)
        {
            throw new NotImplementedException();
        }

        _accessToken = await httpResponse
            .DeserializeContentAsync<AccessToken>()
            .ConfigureAwait(false);

        return _accessToken;
    }

    /// <inheritdoc />
    public async Task<TResponse> MakeRequestAsync<TResponse>(
        IRequest<TResponse> request,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var token = await GetAccessTokenAsync(cancellationToken);

        var url = $"{GigaChatClientOptions.BaseRequestUrl}/{request.MethodName}";

        var httpRequest = new HttpRequestMessage(request.Method, url)
        {
            Content = request.ToHttpContent()
        };

        httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token!.Value);
        httpRequest.Headers.Add("Accept", "application/json");

        using var httpResponse = await SendRequestAsync(
                _httpClient, httpRequest, cancellationToken)
            .ConfigureAwait(false);

        if (httpResponse.StatusCode != HttpStatusCode.OK)
        {
            throw new NotImplementedException();
        }

        var apiResponse = await httpResponse
            .DeserializeContentAsync<TResponse>()
            .ConfigureAwait(false);

        return apiResponse;
    }

    private static async Task<HttpResponseMessage> SendRequestAsync(
        HttpClient httpClient,
        HttpRequestMessage httpRequest,
        CancellationToken cancellationToken)
    {
        HttpResponseMessage? httpResponse;

        try
        {
            httpResponse = await httpClient
                .SendAsync(httpRequest, cancellationToken)
                .ConfigureAwait(false);
        }
        catch (TaskCanceledException ex)
        {
            if (cancellationToken.IsCancellationRequested)
                throw;

            throw new RequestException(
                "Request timed out",
                ex);
        }
        catch (Exception ex)
        {
            throw new RequestException(
                "Exception during making request",
                ex);
        }

        return httpResponse;
    }
}