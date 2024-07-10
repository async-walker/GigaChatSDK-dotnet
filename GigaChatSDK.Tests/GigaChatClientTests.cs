using System.Text;

namespace GigaChatSDK.Tests
{
    public class GigaChatClientTests
    {
        readonly IGigaChatClient _client;

        public GigaChatClientTests()
        {
            var clientId = "";
            var clientSecret = "";

            var authData = Encoding.UTF8.GetBytes($"{clientId}:{clientSecret}");

            _client = new GigaChatClient(
                new GigaChatClientOptions(
                    authData: Convert.ToBase64String(authData)));
        }

        [Fact]
        public async void RefreshTokenAsyncTest()
        {
            await _client.RefreshTokenAsync(default);
        }

        [Fact]
        public async void GetListModelsAsyncTest()
        {
            var models = await _client.GetListModelsAsync(default);

            Assert.NotNull(models);
            Assert.True(models.Models.Count > 0);
        }
    }
}