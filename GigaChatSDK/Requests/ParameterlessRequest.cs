namespace GigaChatSDK.Requests;

/// <summary>
///     Абстракция запроса к API без параметров
/// </summary>
/// <typeparam name="TResponse">Тип ответа</typeparam>
public abstract class ParameterlessRequest<TResponse> : RequestBase<TResponse>
{
    /// <inheritdoc />
    protected ParameterlessRequest(string methodName)
        : base(methodName)
    {
    }

    /// <inheritdoc />
    protected ParameterlessRequest(string methodName, HttpMethod method)
        : base(methodName, method)
    {
    }
}