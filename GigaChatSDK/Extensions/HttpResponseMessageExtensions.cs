using System.Runtime.CompilerServices;
using GigaChatSDK.Exceptions;

namespace GigaChatSDK.Extensions;

internal static class HttpResponseMessageExtensions
{
    /// <summary>
    ///     Десериализация контента из тела ответа в <typeparamref name="TResponse" />
    /// </summary>
    /// <param name="httpResponse">HTTP-ответ</param>
    /// <typeparam name="TResponse">Тип ответа</typeparam>
    /// <returns>Десериализованный в тип ответ</returns>
    /// <exception cref="RequestException" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static async Task<TResponse> DeserializeContentAsync<TResponse>(this HttpResponseMessage httpResponse)
    {
        Stream? contentStream = null;

        if (httpResponse.Content is null)
            throw new RequestException(
                "Ответ не содержит какой-либо контент",
                httpResponse.StatusCode);

        try
        {
            TResponse? deserializedObject;

            try
            {
                contentStream = await httpResponse.Content
                    .ReadAsStreamAsync()
                    .ConfigureAwait(false);

                deserializedObject = contentStream
                    .DeserializeJsonFromStream<TResponse>();
            }
            catch (Exception exception)
            {
                throw CreateRequestException(
                    httpResponse,
                    "Запрашиваемые свойства не найдены в теле ответа",
                    exception);
            }

            if (deserializedObject is null)
                throw CreateRequestException(
                    httpResponse,
                    "Запрашиваемые свойства не найдены в теле ответа");

            return deserializedObject;
        }
        finally
        {
#if NET6_0_OR_GREATER
            if (contentStream is not null) await contentStream.DisposeAsync().ConfigureAwait(false);
#else
            contentStream?.Dispose();
#endif
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static RequestException CreateRequestException(
        HttpResponseMessage httpResponse,
        string message,
        Exception? exception = default)
    {
        return exception is null
            ? new RequestException(
                message,
                httpResponse.StatusCode)
            : new RequestException(
                message,
                httpResponse.StatusCode,
                exception);
    }
}