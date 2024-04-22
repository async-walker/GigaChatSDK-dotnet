using GigaChatSDK.Helpers;
using GigaChatSDK.Types.Data;
using Newtonsoft.Json;
using RestSharp;

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

        public TokenData() { }

        public static TokenData GetTokenData(GigaChatClientOptions chatClientOptions)
        {
            var options = new RestClientOptions(
                baseUrl: ApiEndpoints.AccessTokenEndpoint);

            var tokenClient = new RestClient(options);

            var requestId = Guid.NewGuid().ToString();
            var authHeader = $"Basic {chatClientOptions.AuthData}";

            var request = new RestRequest("oauth", Method.Post)
                .AddHeader("RqUID", requestId)
                .AddHeader("Authorization", authHeader)
                .AddBody($"scope={chatClientOptions.Scope}", ContentType.FormUrlEncoded);

            var response = tokenClient.Execute(request);

            var tokenData = JsonConvert.DeserializeObject<TokenData>(response.Content);

            return tokenData;
        }
    }
}
