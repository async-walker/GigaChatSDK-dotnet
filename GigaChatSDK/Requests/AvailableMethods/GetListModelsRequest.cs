using GigaChatSDK.Data;
using GigaChatSDK.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace GigaChatSDK.Requests.AvailableMethods
{
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class GetListModelsRequest : ParameterlessRequest<ListModels>
    {
        public GetListModelsRequest()
            : base(ApiEndpoints.GigaChatEndpoint, "models", HttpMethod.Get)
        { }
    }
}
