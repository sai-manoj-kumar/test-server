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
    public static class HttpTriggerView
    {
        [FunctionName("HttpTriggerView")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, Route = "view/{*all}")] HttpRequest req,
            ILogger log)
        {
            var properties = ResponseHelper.GetProperties(req);
            return new JsonResult(properties);
        }
    }

    // public class HeaderHelper
    // {
    //     public ActionResult Index()
    //     {
    //         var headerDictionary = new Dictionary<string, string>();
    //         var headerNames = Request.Headers.AllKeys.ToList();
    //         headerNames.Sort();
    //         foreach (var key in headerNames)
    //         {
    //             headerDictionary[key] = Request.Headers[key];
    //         }
    //         ViewBag.RequestHeaders = headerDictionary;
    //         return View();
    //     }

    //     public ActionResult About()
    //     {
    //         ViewBag.Message = "Your application description page.";

    //         return View();
    //     }

    //     public ActionResult Contact()
    //     {
    //         ViewBag.Message = "Your contact page.";

    //         return View();
    //     }
    // }
}
