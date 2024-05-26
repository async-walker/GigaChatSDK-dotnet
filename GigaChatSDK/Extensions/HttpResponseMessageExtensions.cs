using GigaChatSDK.Exceptions;
using System.Runtime.CompilerServices;

namespace GigaChatSDK.Extensions
{
    internal static class HttpResponseMessageExtensions
    {
        /// <summary>
        /// Десериализация контента из тела ответа в <typeparamref name="T"/>
        /// </summary>
        /// <param name="httpResponse">Экземпляр <see cref="HttpResponseMessage"/></param>
        /// <typeparam name="T">Тип результата</typeparam>
        /// <returns></returns>
        /// <exception cref="RequestException">
        /// Возникает когда тело ответа не может быть десериализовано как <typeparamref name="T"/>
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static async Task<T> DeserializeContentAsync<T>(this HttpResponseMessage httpResponse)
        {
            Stream? contentStream = null;

            if (httpResponse.Content is null)
            {
                throw new RequestException(
                    message: "Ответ не содержит какой-либо контент",
                    httpStatusCode: httpResponse.StatusCode);
            }

            try
            {
                T? deserializedObject;

                try
                {
                    contentStream = await httpResponse.Content
                        .ReadAsStreamAsync()
                        .ConfigureAwait(continueOnCapturedContext: false);

                    deserializedObject = contentStream
                        .DeserializeJsonFromStream<T>();
                }
                catch (Exception exception)
                {
                    throw CreateRequestException(
                        httpResponse: httpResponse,
                        message: "Запрашиваемые свойства не найдены в теле ответа",
                        exception: exception
                    );
                }

                if (deserializedObject is null)
                {
                    throw CreateRequestException(
                        httpResponse: httpResponse,
                        message: "Запрашиваемые свойства не найдены в теле ответа"
                    );
                }

                return deserializedObject;
            }
            finally
            {
#if NET6_0_OR_GREATER
                if (contentStream is not null)
                {
                    await contentStream.DisposeAsync().ConfigureAwait(false);
                }
#else
            contentStream?.Dispose();
#endif
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static RequestException CreateRequestException(
            HttpResponseMessage httpResponse,
            string message,
            Exception? exception = default) =>
            exception is null
            ? new(
                message: message,
                httpStatusCode: httpResponse.StatusCode)
            : new(
                message: message,
                httpStatusCode: httpResponse.StatusCode,
                innerException: exception);
    }
}
