namespace GigaChatSDK.Helpers
{
    internal static class DateTimeHelper
    {
        public static DateTime UnixTimeStampToDateTime(long unixTimeStamp)
        {
            var dateTimeOffset = DateTimeOffset.FromUnixTimeMilliseconds(unixTimeStamp);
            
            return dateTimeOffset.DateTime;
        }
    }
}
