namespace GigaChatSDK
{
    public class GigaChatClientOptions
    {
        public string? Token { get; }
        public string ClientId { get; }
        public string ClientSecret { get; }
        public string Scope { get; }
        public bool AutoRefreshToken { get; }

        public GigaChatClientOptions(
            string clientId,
            string clientSecret,
            string scope,
            bool autoRefreshToken,
            string? token = null) 
        {
            Token = token;
            ClientId = clientId;
            ClientSecret = clientSecret;
            Scope = scope;
            AutoRefreshToken = autoRefreshToken;
        }
    }
}
