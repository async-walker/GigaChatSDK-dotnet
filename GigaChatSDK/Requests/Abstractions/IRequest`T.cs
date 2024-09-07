namespace GigaChatSDK.Requests.Abstractions;

/// <summary>
///     Интерфейс запроса для запросов с телом ответа
/// </summary>
/// <typeparam name="TResponse">Тип ответа</typeparam>
public interface IRequest<TResponse> : IRequest;