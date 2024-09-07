namespace GigaChatSDK.Requests.Abstractions;

/// <summary>
///     Интерфейс запроса
/// </summary>
public interface IRequest
{
    /// <summary>
    ///     HTTP-метод
    /// </summary>
    HttpMethod Method { get; }

    /// <summary>
    ///     Вызываемый метод API
    /// </summary>
    string MethodName { get; }

    /// <summary>
    ///     Конвертация тела запроса в <see cref="HttpContent" />
    /// </summary>
    /// <returns></returns>
    HttpContent? ToHttpContent();
}