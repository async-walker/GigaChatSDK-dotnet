using GigaChatSDK.Helpers;
using Newtonsoft.Json;

namespace GigaChatSDK.Types
{
    public class TokenData
    {
        [JsonIgnore]
        public string Token { get; set; } = default!;
        [JsonIgnore]
        public DateTime Expires { get; set; } = default!;

        [JsonConstructor]
        public TokenData(
            [JsonProperty("access_token")] string token, 
            [JsonProperty("expires_at")] long expires)
        {
            Token = token;
            Expires = DateTimeHelper.UnixTimeStampToDateTime(expires);
        }
    }
}
