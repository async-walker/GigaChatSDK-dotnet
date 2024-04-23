using Newtonsoft.Json;

namespace GigaChatSDK.Types
{
    public sealed class ModelInfo
    {
        [JsonProperty("Id")]
        public string Name { get; set; } = default!;
        [JsonProperty("object")]
        public string EntityType { get; set; } = default!;
        [JsonProperty("owned_by")]
        public string Owner { get; set; } = default!;
    }
}
