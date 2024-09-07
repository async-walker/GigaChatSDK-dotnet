using GigaChatSDK.Requests.Abstractions;
using GigaChatSDK.Types;

namespace GigaChatSDK;

/// <summary>
///     Интерфейс для взаимодействия с API
/// </summary>
public interface IGigaChatClient
{
    /// <summary>
    ///     Используйте этот метод для получения токена доступа
    /// </summary>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Данные токена</returns>
    Task<AccessToken?> GetAccessTokenAsync(CancellationToken cancellationToken);

    /// <summary>
    ///     Используйте этот метод для выполнения запросов
    /// </summary>
    /// <typeparam name="TResponse">Тип ответа</typeparam>
    /// <param name="request">Запрос к API</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Ответ, десериализованный по типу из запроса</returns>
    Task<TResponse> MakeRequestAsync<TResponse>(
        IRequest<TResponse> request,
        CancellationToken cancellationToken);
}