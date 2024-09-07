using GigaChatSDK.Types;

namespace GigaChatSDK.Requests.AvailableMethods;

/// <summary>
///     Запрос на получение доступных моделей
/// </summary>
public class GetAvailableModelsRequest() : ParameterlessRequest<AvailableModels>("models", HttpMethod.Get);