using Newtonsoft.Json;

namespace GigaChatSDK.Types
{
    public sealed class ListModels
    {
        [JsonProperty("data")]
        public List<ModelInfo> Models { get; set; } = default!;
        [JsonProperty("object")]
        public string Type { get; set; } = default!;
    }
}
