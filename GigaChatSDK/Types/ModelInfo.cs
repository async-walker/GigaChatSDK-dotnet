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
    public string Model { get; set; } = default!;

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