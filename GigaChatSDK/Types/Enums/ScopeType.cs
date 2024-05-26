using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace GigaChatSDK.Types.Enums
{
    /// <summary>
    /// Версия API для использования
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ScopeType
    {
        /// <summary>
        /// Для физических лиц
        /// </summary>
        [EnumMember(Value = "GIGACHAT_API_PERS")]
        Personal,
        /// <summary>
        /// Для ИП/ЮЛ
        /// </summary>
        [EnumMember(Value = "GIGACHAT_API_CORP")]
        Corporative
    }
}
