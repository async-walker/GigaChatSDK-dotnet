using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace GigaChatSDK.Extensions;

internal static class StreamExtensions
{
    /// <summary>
    ///     Десериализация JSON из потока в <typeparamref name="TResponse" />
    /// </summary>
    /// <param name="stream"><see cref="Stream" /> содержащий контент для десериализации</param>
    /// <typeparam name="TResponse">Тип ответа</typeparam>
    /// <returns>Десериализованный экземепляр <typeparamref name="TResponse" /> или <c>null</c></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TResponse? DeserializeJsonFromStream<TResponse>(this Stream? stream)
    {
        if (stream is null || !stream.CanRead) return default;

        using var streamReader = new StreamReader(stream);
        using var jsonTextReader = new JsonTextReader(streamReader);

        var serializerSettings = new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            },
            Formatting = Formatting.Indented
        };

        var jsonSerializer = JsonSerializer.CreateDefault(serializerSettings);
        var searchResult = jsonSerializer.Deserialize<TResponse>(jsonTextReader);

        return searchResult;
    }
}