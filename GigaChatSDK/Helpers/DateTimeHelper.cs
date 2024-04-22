namespace GigaChatSDK.Helpers
{
    internal static class DateTimeHelper
    {
        public static DateTime UnixTimeStampToDateTime(long unixTimeStamp)
        {
            var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddMilliseconds(unixTimeStamp).ToLocalTime();
            
            return dateTime;
        }
    }
}
