using System.Runtime.Serialization;

namespace GigaChatSDK.Types.Enums;

/// <summary>
///     Версия API для использования
/// </summary>
public enum ScopeType
{
    /// <summary>
    ///     Доступ для физических лиц
    /// </summary>
    [EnumMember(Value = "GIGACHAT_API_PERS")]
    Personal,

    /// <summary>
    ///     Доступ для ИП и юридических лиц по
    ///     <a href="https://developers.sber.ru/docs/ru/gigachat/api/tariffs#platnye-pakety-pri-rabote-po-predoplatnoy-sheme">предоплате</a>
    /// </summary>
    [EnumMember(Value = "GIGACHAT_API_B2B")]
    B2B,

    /// <summary>
    ///     Доступ для ИП и юридических лиц по
    ///     <a href="https://developers.sber.ru/docs/ru/gigachat/api/legal-postpaid">постоплате</a>
    /// </summary>
    [EnumMember(Value = "GIGACHAT_API_CORP")]
    Corporate
}