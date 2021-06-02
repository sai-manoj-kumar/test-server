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
using System.Text;
using System.Net.Http.Headers;

namespace TestBackendServer.Function
{
    public static class HttpTriggerLatency
    {
        [FunctionName("HttpTriggerLatency")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, Route = "latency/{size}/")] HttpRequest req,
            ILogger log)
        {
            int numberOfKiloBytes;
            var size = req.Path.ToString().Split("/").Last();
            if (!Int32.TryParse(size, out numberOfKiloBytes))
            {
                numberOfKiloBytes = 1;
            }
            if (numberOfKiloBytes > 1024 * 100)
            {
                // If requested for more than 100 MB response, limit it to just 10MB. DoS prevention
                numberOfKiloBytes = 1024 * 10;
            }

            return new ContentResult()
            {
                Content = ResponseHelper.GenerateString(numberOfKiloBytes * 1024)
            };
        }
    }
}
