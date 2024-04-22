using System.Text;

namespace GigaChatSDK.Extensions
{
    internal static class StringExtensions
    {
        public static string EncodeToBase64(this string value)
        {
            var bytes = Encoding.UTF8.GetBytes(value);
            var encode = Convert.ToBase64String(bytes);

            return encode;
        }
    }
}
