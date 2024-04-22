using GigaChatSDK.Types.Data;

namespace GigaChatSDK.Tests
{
    public class GigaChatClientTests
    {
        IGigaChatClient _client;

        public GigaChatClientTests()
        {
            var clientId = "";
            var clientSecret = "";

            _client = new GigaChatClient(
                new GigaChatClientOptions(clientId, clientSecret, ScopeConstants.PERSONAL_SCOPE));
        }

        [Fact]
        public void Test1()
        {
            var e = _client.GetToken();
        }
    }
}