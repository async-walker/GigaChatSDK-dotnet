using GigaChatSDK.Types.Enums;

namespace GigaChatSDK
{
    public class GigaChatClientOptions
    {
        public ScopeType Scope { get; }
        public string AuthData { get; }
        public bool AutoRefreshToken { get; }
        public string BaseRefreshTokenUrl { get; }
        public string BaseRequestUrl { get; }

        public GigaChatClientOptions(
            string authData,
            ScopeType scope = ScopeType.Personal,
            bool autoRefreshToken = true) 
        {
            AuthData = authData;
            Scope = scope;
            AutoRefreshToken = autoRefreshToken;
            BaseRefreshTokenUrl = "https://ngw.devices.sberbank.ru:9443/api/v2";
            BaseRequestUrl = "https://gigachat.devices.sberbank.ru/api/v1";
        }
    }
}
