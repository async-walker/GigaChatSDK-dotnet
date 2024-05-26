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
        public string Url { get; }
        [JsonIgnore]
        public string MethodName { get; }

        protected RequestBase(string url, string methodName)
            : this(url, methodName, HttpMethod.Post)
        { }

        protected RequestBase(string url, string methodName, HttpMethod method) =>
            (Url, MethodName, Method) = (url, methodName, method);

        public virtual HttpContent? ToHttpContent() =>
            new StringContent(
                content: JsonConvert.SerializeObject(this),
                encoding: Encoding.UTF8,
                mediaType: "application/json");
    }
}
