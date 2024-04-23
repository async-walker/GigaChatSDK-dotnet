using GigaChatSDK.Extensions;
using GigaChatSDK.Helpers;
using GigaChatSDK.Types.Data;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;

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

        public static async Task<TokenData> GetTokenData(GigaChatClientOptions chatClientOptions)
        {
            var options = new RestClientOptions(
                baseUrl: ApiEndpoints.AccessTokenEndpoint)
            {
                Authenticator = new HttpBasicAuthenticator(chatClientOptions.ClientId, chatClientOptions.ClientSecret)
            };

            var tokenClient = new RestClient(options);

            var requestId = Guid.NewGuid().ToString();

            var request = new RestRequest("oauth", Method.Post)
                .AddHeader("RqUID", requestId)
                .AddBody($"scope={chatClientOptions.Scope}", ContentType.FormUrlEncoded);

            var response = await tokenClient.GetResponseAsync(request);

            var tokenData = JsonConvert.DeserializeObject<TokenData>(response.Content!);

            return tokenData ?? 
                throw new NullReferenceException("TokenData after deserialize response content is null");
        }
    }
}
