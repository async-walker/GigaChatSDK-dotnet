using GigaChatSDK.Types.Enums;
using Newtonsoft.Json;

namespace GigaChatSDK.Types;

/// <summary>
///     Информация о модели
/// </summary>
public class ModelInfo
{
    /// <summary>
    ///     Название модели
    /// </summary>
    [JsonProperty("id")]
    public GigaChatModel Model { get; set; }

    /// <summary>
    ///     Тип сущности в ответе, например, модель
    /// </summary>
    [JsonProperty("object")]
    public string EntityType { get; set; } = default!;

    /// <summary>
    ///     Владелец модели
    /// </summary>
    [JsonProperty("owned_by")]
    public string Owner { get; set; } = default!;
}