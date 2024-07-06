using GigaChatSDK.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace GigaChatSDK.Requests.AvailableMethods
{
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class GetTokenDataRequest : RequestBase<TokenData>
    {
        public GetTokenDataRequest()
            : base("oauth", HttpMethod.Post)
        { }
    }
}
