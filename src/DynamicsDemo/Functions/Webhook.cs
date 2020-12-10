using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.PowerPlatform.Cds.Client;

namespace Functions
{
    /// <summary>
    ///  sample repository - https://github.com/microsoft/PowerApps-Samples/tree/master/cds/orgsvc/C%23
    /// </summary>
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

            //getting connection string 
            //https://docs.microsoft.com/en-us/powerapps/developer/common-data-service/xrm-tooling/use-connection-strings-xrm-tooling-connect
            var connectionString = Environment.GetEnvironmentVariable("CDSConnString");
            
            var svc = new CdsServiceClient(connectionString);
            var myCdsUserId = svc.GetMyCdsUserId();
            
            //DO OTHER OPERATIONS
            
            watch.Stop();

            string elapsedInfo = $"Report and execution from Dynamics lasted for {watch.ElapsedMilliseconds} ms ({watch.Elapsed.Seconds} s) for user @{myCdsUserId}";

            return (ActionResult) new OkObjectResult(elapsedInfo);

        }
    }
}