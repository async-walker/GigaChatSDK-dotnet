using GigaChatSDK.Extensions;
using GigaChatSDK.Requests.AvailableMethods;
using GigaChatSDK.Types;

namespace GigaChatSDK
{
    public static class GigaChatClientExtensions
    {
        public static async Task<ListModels> GetListModelsAsync(
            this IGigaChatClient client,
            CancellationToken cancellationToken = default) =>
            await client.ThrowIfNull()
                .MakeRequestAsync(
                    request: new GetListModelsRequest(),
                    cancellationToken)
                .ConfigureAwait(false);
    }
}
