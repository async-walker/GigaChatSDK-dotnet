using GigaChatSDK.Requests.Abstractions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Text;

namespace GigaChatSDK.Requests
{
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public abstract class RequestBase<TResponse> : IRequest<TResponse>
    {
        [JsonIgnore]
        public HttpMethod Method { get; }
        [JsonIgnore]
        public string MethodName { get; }

        protected RequestBase(string methodName)
            : this(methodName, HttpMethod.Post)
        { }

        protected RequestBase(string methodName, HttpMethod method) =>
            (MethodName, Method) = (methodName, method);

        public virtual HttpContent? ToHttpContent() =>
            new StringContent(
                content: JsonConvert.SerializeObject(this),
                encoding: Encoding.UTF8,
                mediaType: "application/json");
    }
}
