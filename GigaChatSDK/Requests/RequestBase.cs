using System.Text;
using GigaChatSDK.Requests.Abstractions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace GigaChatSDK.Requests;

/// <summary>
///     Абстракция запроса к API
/// </summary>
/// <typeparam name="TResponse">Тип ответа</typeparam>
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public abstract class RequestBase<TResponse> : IRequest<TResponse>
{
    /// <summary>
    ///     Инициализация запроса
    /// </summary>
    /// <param name="methodName">Метод API</param>
    protected RequestBase(string methodName)
        : this(methodName, HttpMethod.Post)
    {
    }

    /// <summary>
    ///     Инициализация запроса
    /// </summary>
    /// <param name="methodName">Метод API</param>
    /// <param name="method">HTTP-метод</param>
    protected RequestBase(string methodName, HttpMethod method)
    {
        (MethodName, Method) = (methodName, method);
    }

    /// <inheritdoc />
    [JsonIgnore]
    public HttpMethod Method { get; }

    /// <inheritdoc />
    [JsonIgnore]
    public string MethodName { get; }

    /// <inheritdoc />
    public virtual HttpContent? ToHttpContent()
    {
        return new StringContent(
            JsonConvert.SerializeObject(this),
            Encoding.UTF8,
            "application/json");
    }
}