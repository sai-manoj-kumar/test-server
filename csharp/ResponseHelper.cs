using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System;
using System.Text;

namespace TestBackendServer.Function
{
    public static class ResponseHelper
    {
        private static string bigOutputPool = "";

        static ResponseHelper()
        {
            bigOutputPool = RandomString((1024 * 1024 * 100) + 10);
        }

        public static Dictionary<string, string> GetProperties(HttpRequest request)
        {
            
            var properties = request.Headers.Where(
                x => !string.Equals(x.Key, "User-Agent", StringComparison.CurrentCultureIgnoreCase)).Select(
                x => new KeyValuePair<string, string>(x.Key, string.Join(",", x.Value))).ToDictionary(y => y.Key, y => y.Value);
            properties["User-Agent"] = request.Headers["User-Agent"].ToString();
            properties["Method"] = request.Method;
            properties["Path"] = request.Path;
            if (request.QueryString.HasValue) {
                properties["QueryString"] = request.QueryString.Value;
            }
            
            return properties;
        }

        public static string RandomString_Old(int length)
        {
            const string pool = "abcdefghijklmnopqrstuvwyxzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var chars = Enumerable.Range(0, length)
                .Select(x => pool[random.Next(0, pool.Length)]);
            return new string(chars.ToArray());
        }

        public static string RandomString_Old2(int length)
        {
            const string pool = "abcdefghijklmnopqrstuvwyxzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var builder = new StringBuilder();
            var random = new Random();

            for (var i = 0; i < length; i++)
            {
                var c = pool[random.Next(0, pool.Length)];
                builder.Append(c);
            }

            return builder.ToString();
        }

        public static string RandomString(long length)
        {
            var bytes = new byte[length];
            var random = new Random();
            random.NextBytes(bytes);
            return Convert.ToBase64String(bytes, 0, bytes.Length);
        }


        public static string GenerateString(int count)
        {
            int startIndex = new Random().Next(10);
            return bigOutputPool.Substring(startIndex, count);
        }
    }
}