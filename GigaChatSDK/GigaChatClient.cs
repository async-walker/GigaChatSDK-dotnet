using GigaChatSDK.Types;
using RestSharp;

namespace GigaChatSDK
{
    public class GigaChatClient : IGigaChatClient, IDisposable
    {
        static TokenData _tokenData;

        private readonly IRestClient _chatClient;
        private readonly GigaChatClientOptions _clientOptions;

        public GigaChatClient(GigaChatClientOptions clientOptions)
        {
            if ((_tokenData == null) || (_tokenData.Expires < DateTime.UtcNow))
                _tokenData = TokenData.GetTokenData(clientOptions);

            _chatClient = new RestClient();
            _clientOptions = clientOptions;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<TokenData> GetToken()
        {
            throw new NotImplementedException();
        }
    }
}
