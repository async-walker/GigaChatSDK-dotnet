using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace GigaChatSDK.Requests
{
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public abstract class ParameterlessRequest<TResult> : RequestBase<TResult>
    {
        protected ParameterlessRequest(string url, string methodName)
            : base(url, methodName)
        { }

        protected ParameterlessRequest(string url, string methodName, HttpMethod method)
            : base(url, methodName, method)
        { }

        public override HttpContent? ToHttpContent() =>
            base.ToHttpContent();
    }
}
