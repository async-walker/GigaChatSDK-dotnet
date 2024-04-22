using GigaChatSDK.Extensions;

namespace GigaChatSDK
{
    /// <summary>
    /// 
    /// </summary>
    public class GigaChatClientOptions
    {
        private readonly string ClientId;
        private readonly string ClientSecret;

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

        public string AuthData 
        {
            get
            {
                var template = $"{ClientId}:{ClientSecret}";

                return template.EncodeToBase64();
            }
        }

        public string Scope { get; set; }
    }
}
