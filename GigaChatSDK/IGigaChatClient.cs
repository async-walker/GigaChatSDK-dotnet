using GigaChatSDK.Requests.Abstractions;

namespace GigaChatSDK
{
    public interface IGigaChatClient
    {
        Task RefreshTokenAsync(CancellationToken cancellationToken);
        Task<TResponse> MakeRequestAsync<TResponse>(
            IRequest<TResponse> request, 
            CancellationToken cancellationToken);
    }
}
