namespace GigaChatSDK.Requests.Abstractions
{
    public interface IRequest
    {
        HttpMethod Method { get; }
        string Url { get; }
        string MethodName { get; }
        HttpContent? ToHttpContent();
    }
}
