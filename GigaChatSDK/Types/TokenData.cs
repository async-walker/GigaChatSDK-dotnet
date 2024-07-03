using GigaChatSDK.Helpers;
using Newtonsoft.Json;

namespace GigaChatSDK.Types
{
    [method: JsonConstructor]
    public class TokenData(
        [JsonProperty("access_token")] string token,
        [JsonProperty("expires_at")] long expires)
    {
        [JsonIgnore]
        public string Token { get; set; } = token;
        [JsonIgnore]
        public DateTime Expires { get; set; } = DateTimeHelper.UnixTimeStampToDateTime(expires);
    }
}
