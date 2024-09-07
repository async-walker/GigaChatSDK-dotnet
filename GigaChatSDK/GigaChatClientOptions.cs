using GigaChatSDK.Types.Enums;

namespace GigaChatSDK;

/// <summary>
///     Конфигурация для <see cref="GigaChatClient" />
/// </summary>
/// <param name="authData">Авторизационные данные в формате Base64 (Basic авторизационные_данные)</param>
/// <param name="scope">Версия API для запроса (персональный / бизнес)</param>
/// <param name="autoRefreshToken">Использование автоматического обновления токена по истечении срока действия (30 минут)</param>
public class GigaChatClientOptions(
    string authData,
    ScopeType scope = ScopeType.Personal,
    bool autoRefreshToken = true)
{
    /// <summary>
    ///     Базовый адрес для получения токена доступа
    /// </summary>
    public const string BaseAccessTokenUrl = "https://ngw.devices.sberbank.ru:9443/api/v2";

    /// <summary>
    ///     Базовый адрес для выполнения запросов API
    /// </summary>
    public const string BaseRequestUrl = "https://gigachat.devices.sberbank.ru/api/v1";

    /// <summary>
    ///     Версия API для использования
    /// </summary>
    public ScopeType Scope { get; } = scope;

    /// <summary>
    ///     Авторизационные данные
    /// </summary>
    public string AuthData { get; } = authData;

    /// <summary>
    ///     Автообновление токена
    /// </summary>
    public bool AutoRefreshToken { get; } = autoRefreshToken;
}