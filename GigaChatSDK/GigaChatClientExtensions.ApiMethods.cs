using GigaChatSDK.Extensions;
using GigaChatSDK.Requests.AvailableMethods;
using GigaChatSDK.Types;

namespace GigaChatSDK;

public static class GigaChatClientExtensions
{
    /// <summary>
    ///     Получение доступных моделей генерации
    /// </summary>
    /// <param name="client">Клиент <see cref="IGigaChatClient" /></param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Список доступных моделей <see cref="ModelInfo" /></returns>
    public static async Task<ListModels> GetAvailableModelsAsync(
        this IGigaChatClient client,
        CancellationToken cancellationToken = default)
    {
        return await client.ThrowIfNull()
            .MakeRequestAsync(
                new GetAvailableModelsRequest(),
                cancellationToken)
            .ConfigureAwait(false);
    }
}