using GigaChatSDK.Types;

namespace GigaChatSDK
{
    public interface IGigaChatClient
    {
        Task<TokenData> GetToken();
    }
}
