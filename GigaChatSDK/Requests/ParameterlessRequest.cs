using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace GigaChatSDK.Requests
{
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public abstract class ParameterlessRequest<TResult> : RequestBase<TResult>
    {
        protected ParameterlessRequest(string methodName)
            : base(methodName)
        { }

        protected ParameterlessRequest(string methodName, HttpMethod method)
            : base(methodName, method)
        { }

        public override HttpContent? ToHttpContent() =>
            base.ToHttpContent();
    }
}
