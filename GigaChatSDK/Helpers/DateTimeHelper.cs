namespace GigaChatSDK.Helpers;

internal static class DateTimeHelper
{
    public static DateTimeOffset UnixTimeStampToDateTime(long unixTimeStamp)
    {
        var dateTimeOffset = DateTimeOffset.FromUnixTimeMilliseconds(unixTimeStamp);

        return dateTimeOffset;
    }
}