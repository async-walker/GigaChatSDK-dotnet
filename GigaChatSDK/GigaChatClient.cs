using GigaChatSDK.Data;
using GigaChatSDK.Exceptions;
using GigaChatSDK.Extensions;
using GigaChatSDK.Requests.Abstractions;
using GigaChatSDK.Requests.AvailableMethods;
using GigaChatSDK.Types;
using System.Net;
using System.Runtime.CompilerServices;

namespace GigaChatSDK
{
    public class GigaChatClient : IGigaChatClient, IDisposable
    {
        static TokenData _tokenData = default!;

        readonly GigaChatClientOptions _options;
        readonly HttpClient _httpClient;

        public GigaChatClient(
            GigaChatClientOptions options,
            HttpClient? httpClient = default)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
            _httpClient = httpClient ?? new HttpClient();
        }

        public void Dispose() => GC.SuppressFinalize(this);

        public async Task RefreshTokenAsync(CancellationToken cancellationToken)
        {

            var collection = new List<KeyValuePair<string, string>>
            {
                new("scope", _options.Scope.GetEnumMemberValue())
            };
            var url = $"{_options.BaseRefreshTokenUrl}/oauth";

            var httpRequest = new HttpRequestMessage(method: HttpMethod.Post, requestUri: url)
            {
                Content = new FormUrlEncodedContent(collection)
            };

            httpRequest.Headers.Add("Authorization", $"Basic {_options.AuthData}");
            httpRequest.Headers.TryAddWithoutValidation("Content-Type", "application/x-www-form-urlencoded");
            httpRequest.Headers.Add("Accept", "application/json");
            httpRequest.Headers.Add("RqUID", Guid.NewGuid().ToString());

            using var httpResponse = await SendRequestAsync(
                httpClient: _httpClient,
                httpRequest: httpRequest,
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);

            if (httpResponse.StatusCode != HttpStatusCode.OK)
            {
                //var failedApiResponse = await httpResponse
                //.DeserializeContentAsync<ApiResponse>(
                //    guard: response =>
                //        response.ErrorCode == default ||
                //        response.Description is null
                //)
                //.ConfigureAwait(false);

                //throw ExceptionsParser.Parse(failedApiResponse);
                throw new NotImplementedException();
            }

            var tokenData = await httpResponse
                .DeserializeContentAsync<TokenData>()
                .ConfigureAwait(false);

            _tokenData = tokenData;
        }

        public async Task<TResponse> MakeRequestAsync<TResponse>(
            IRequest<TResponse> request,
            CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            if (request is not GetTokenDataRequest)

            if (_options.AutoRefreshToken && ((_tokenData == null) || (_tokenData.Expires < DateTime.UtcNow)))
                await RefreshTokenAsync(cancellationToken);

            var url = $"{_options.BaseRequestUrl}/{request.MethodName}";
            
            var httpRequest = new HttpRequestMessage(request.Method, url)
            {
                Content = request.ToHttpContent(),
            };

            using var httpResponse = await SendRequestAsync(
                httpClient: _httpClient,
                httpRequest: httpRequest,
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);

            if (httpResponse.StatusCode != HttpStatusCode.OK)
            {
                //var failedApiResponse = await httpResponse
                //.DeserializeContentAsync<ApiResponse>(
                //    guard: response =>
                //        response.ErrorCode == default ||
                //        response.Description is null
                //)
                //.ConfigureAwait(false);

                //throw ExceptionsParser.Parse(failedApiResponse);
                throw new NotImplementedException();
            }

            var apiResponse = await httpResponse
                .DeserializeContentAsync<TResponse>()
                .ConfigureAwait(false);

            return apiResponse;
        }

        [MethodImpl(methodImplOptions: MethodImplOptions.AggressiveInlining)]
        static async Task<HttpResponseMessage> SendRequestAsync(
            HttpClient httpClient,
            HttpRequestMessage httpRequest,
            CancellationToken cancellationToken)
        {
            HttpResponseMessage? httpResponse;
            try
            {
                httpResponse = await httpClient
                    .SendAsync(httpRequest, cancellationToken)
                    .ConfigureAwait(continueOnCapturedContext: false);
            }
            catch (TaskCanceledException exception)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    throw;
                }

                throw new RequestException(
                    message: "Request timed out",
                    innerException: exception);
            }
            catch (Exception exception)
            {
                throw new RequestException(
                    message: "Exception during making request",
                    innerException: exception
                );
            }

            return httpResponse;
        }
    }
}
