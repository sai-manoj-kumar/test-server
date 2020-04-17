using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TestBackendServer.Function
{
    public static class HttpTriggerApi
    {
        [FunctionName("HttpTriggerApi")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, Route = "api/{*all}")] HttpRequest req,
            ILogger log)
        {
            var properties = ResponseHelper.GetProperties(req);
            return new JsonResult(properties);
        }
    }
}
