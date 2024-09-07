using GigaChatSDK.Helpers;
using Newtonsoft.Json;

namespace GigaChatSDK.Types;

/// <summary>
///     Токен доступа к методам API
/// </summary>
/// <param name="accessToken"></param>
/// <param name="expiresAt"></param>
[method: JsonConstructor]
public class AccessToken(
    string accessToken,
    long expiresAt)
{
    /// <summary>
    ///     Значение токена
    /// </summary>
    public string Value { get; set; } = accessToken;

    /// <summary>
    ///     Время, до которого действует токен (UTC)
    /// </summary>
    public DateTime ExpiresAt { get; set; } = DateTimeHelper.UnixTimeStampToDateTime(expiresAt);
}