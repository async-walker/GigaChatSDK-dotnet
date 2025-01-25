using Newtonsoft.Json;

namespace GigaChatSDK.Types;

public class ListModels
{
    [JsonProperty("data")]
    public ModelInfo[] Models { get; set; } = default!;

    [JsonProperty("object")]
    public string Type { get; set; } = default!;
}