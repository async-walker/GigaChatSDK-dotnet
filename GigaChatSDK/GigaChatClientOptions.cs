namespace GigaChatSDK
{
    /// <summary>
    /// 
    /// </summary>
    public class GigaChatClientOptions
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string Scope { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <param name="scope"></param>
        public GigaChatClientOptions(
            string clientId,
            string clientSecret,
            string scope) 
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
            Scope = scope;
        }
    }
}
