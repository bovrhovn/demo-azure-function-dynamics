using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

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
            
            //TODO: report from Dynamics and execution
            
            // string name = req.Query["name"];
            //
            // string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            // dynamic data = JsonConvert.DeserializeObject(requestBody);
            // name = name ?? data?.name;
            
            watch.Stop();

            string elapsedInfo = $"Report and execution from Dynamics lasted for {watch.ElapsedMilliseconds} ms ({watch.Elapsed.Seconds} s)";

            return (ActionResult) new OkObjectResult(elapsedInfo);

        }
    }
}