namespace GigaChatSDK.Requests.Abstractions
{
    public interface IRequest
    {
        HttpMethod Method { get; }
        string MethodName { get; }
        HttpContent? ToHttpContent();
    }
}
