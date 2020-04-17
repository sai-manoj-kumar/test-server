using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System;

namespace TestBackendServer.Function
{
    public static class ResponseHelper
    {
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
    }
}