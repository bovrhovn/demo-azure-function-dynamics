using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Functions.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Functions
{
    public static class Webhook
    {
        [FunctionName("Webhook")]
        public static async Task<IActionResult> RunAsync(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]
            HttpRequest req, ILogger log)
        {
            log.LogInformation($"Webhook activated at {DateTime.Now}");

            var watch = new Stopwatch();
            watch.Start();
            
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            log.LogInformation(requestBody);

            var response = JsonConvert.DeserializeObject<WebhookResponse>(requestBody);
            
            //TODO: save back to Dynamics into Account
            
            
            watch.Stop();

            string elapsedInfo = $"Report and execution from Dynamics lasted for {watch.ElapsedMilliseconds} ms ({watch.Elapsed.Seconds} s)";

            return (ActionResult) new OkObjectResult(elapsedInfo);

        }
    }
}