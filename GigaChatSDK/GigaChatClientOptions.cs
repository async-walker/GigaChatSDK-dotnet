using GigaChatSDK.Types.Enums;

namespace GigaChatSDK
{
    public class GigaChatClientOptions
    {
        public ScopeType Scope { get; }
        public string AuthData { get; }
        public bool AutoRefreshToken { get; }

        public GigaChatClientOptions(
            string authData,
            ScopeType scope = ScopeType.Personal,
            bool autoRefreshToken = true) 
        {
            AuthData = authData;
            Scope = scope;
            AutoRefreshToken = autoRefreshToken;
        }
    }
}
