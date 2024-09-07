using System.Text;
using GigaChatSDK.Types.Enums;

namespace GigaChatSDK.UnitTests;

public class GigaChatClientTests
{
    private static IGigaChatClient InitClient(bool autoRefreshToken = true)
    {
        const string clientId = "{YOUR_CLIENT_ID}";
        const string clientSecret = "{YOUR_CLIENT_SECRET}";

        var authData = Encoding.UTF8.GetBytes($"{clientId}:{clientSecret}");

        var client = new GigaChatClient(
            new GigaChatClientOptions(
                Convert.ToBase64String(authData),
                ScopeType.Personal,
                autoRefreshToken));

        return client;
    }

    [Fact(DisplayName = "Получение токена доступа с автообновлением токена")]
    public async void AccessToken_GetIfAutoRefresh_ShouldReturnNotNull()
    {
        var client = InitClient();

        var accessToken = await client.GetAccessTokenAsync(default);

        Assert.NotNull(accessToken);
    }

    [Fact(DisplayName = "Получение токена доступа без автообновления токена при первом обращении")]
    public async void AccessToken_GetIfNotAutoRefreshAndCallFirstTime_ShouldReturnNull()
    {
        var client = InitClient(false);

        var accessToken = await client.GetAccessTokenAsync(default);

        Assert.Null(accessToken);
    }

    [Fact(DisplayName = "Получение доступных моделей")]
    public async void AvailableModels_Get_ReturnCountOverZero()
    {
        var client = InitClient();

        var models = await client.GetAvailableModelsAsync();

        Assert.NotNull(models);
        Assert.True(models.Models.Length > 0);
    }
}