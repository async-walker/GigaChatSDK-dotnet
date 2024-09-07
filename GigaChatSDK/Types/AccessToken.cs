using GigaChatSDK.Helpers;
using Newtonsoft.Json;

namespace GigaChatSDK.Types;

/// <summary>
///     Токен доступа к методам API
/// </summary>
/// <param name="value">Значение</param>
/// <param name="expires">Время действия в Unix формате</param>
[method: JsonConstructor]
public class AccessToken(
    [JsonProperty("access_token")] string value,
    [JsonProperty("expires_at")] long expires)
{
    /// <summary>
    ///     Значение токена
    /// </summary>
    [JsonIgnore]
    public string Value { get; set; } = value;

    /// <summary>
    ///     Время, до которого действует токен (UTC)
    /// </summary>
    [JsonIgnore]
    public DateTime Expires { get; set; } = DateTimeHelper.UnixTimeStampToDateTime(expires);
}