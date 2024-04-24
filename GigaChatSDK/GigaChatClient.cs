using GigaChatSDK.Exceptions;
using GigaChatSDK.Extensions;
using GigaChatSDK.Requests.Abstractions;
using GigaChatSDK.Types;
using GigaChatSDK.Types.Data;
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

        public async Task<TokenData> RefreshTokenAsync(CancellationToken cancellationToken)
        {

        }

        public async Task<TResponse> MakeRequestAsync<TResponse>(
            IRequest<TResponse> request,
            CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            if (_options.AutoRefreshToken && ((_tokenData == null) || (_tokenData.Expires < DateTime.UtcNow)))
                await RefreshTokenAsync(cancellationToken);



            //if ((_tokenData == null) || (_tokenData.Expires < DateTime.UtcNow))
            //{
            //    var url = $"{ApiEndpoints.AccessTokenEndpoint}/{request.MethodName}";

            //    _tokenData = await TokenData.GetTokenData(_options);
            //}

            var url = $"{ApiEndpoints.GigaChatEndpoint}/{request.MethodName}";

            var httpRequest = new HttpRequestMessage(method: request.Method, requestUri: url)
            {
                Content = request.ToHttpContent(),
            };

            //httpRequest.Headers.TryAddWithoutValidation(
            //    name: "Authorization",
            //    value: $"Basic {}");

            using var httpResponse = await SendRequestAsync(
                httpClient: _httpClient,
                httpRequest: httpRequest,
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);

            var apiResponse = await httpResponse
                .DeserializeContentAsync<ApiResponse<TResponse>>(
                guard: response => !response.Ok ||
                                   response.Result is null
            )
            .ConfigureAwait(false);

            return apiResponse.Result!;

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
}
