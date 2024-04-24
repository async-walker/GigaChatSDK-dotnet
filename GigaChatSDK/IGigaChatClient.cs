using GigaChatSDK.Requests.Abstractions;

namespace GigaChatSDK
{
    public interface IGigaChatClient
    {
        Task<TResponse> MakeRequestAsync<TResponse>(
            IRequest<TResponse> request, 
            CancellationToken cancellationToken);
    }
}
