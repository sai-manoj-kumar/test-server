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
            if (numberOfKiloBytes > 1024 * 25)
            {
                numberOfKiloBytes = 1024;
            }
            string textContent = ResponseHelper.RandomString(numberOfKiloBytes * 1024);

            return new ContentResult()
            {
                Content = textContent
            };
        }
    }
}
