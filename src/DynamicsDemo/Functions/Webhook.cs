using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.PowerPlatform.Cds.Client;
using Microsoft.WindowsAzure.Storage.Queue;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

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
            HttpRequest req,
            [Queue("e-commerce-emails")] IAsyncCollector<CloudQueueMessage> messages,
            ILogger log)
        {
            log.LogInformation($"Webhook activated at {DateTime.Now}");

            var watch = new Stopwatch();
            watch.Start();

            //getting connection string 
            //https://docs.microsoft.com/en-us/powerapps/developer/common-data-service/xrm-tooling/use-connection-strings-xrm-tooling-connect
            var connectionString = Environment.GetEnvironmentVariable("CDSConnString");

            var svc = new CdsServiceClient(connectionString);
            var myCdsUserId = svc.GetMyCdsUserId();

            var qe = new QueryExpression {EntityName = "account", ColumnSet = new ColumnSet()};
            qe.ColumnSet.Columns.Add("name");

            qe.LinkEntities.Add(new LinkEntity("account", "contact", "primarycontactid", "contactid",
                JoinOperator.Inner));
            qe.LinkEntities[0].Columns.AddColumns("firstname", "lastname");
            qe.LinkEntities[0].EntityAlias = "primarycontact";

            var ec = svc.RetrieveMultiple(qe);

            string currentEmailContent = string.Empty;
            foreach (var act in ec.Entities)
            {
                var accountName = act["name"]?.ToString();
                var firstName = act.GetAttributeValue<AliasedValue>("primarycontact.firstname")?.Value?.ToString();
                var lastName = act.GetAttributeValue<AliasedValue>("primarycontact.lastname")?.Value?.ToString();

                currentEmailContent += $"Account  {accountName}: {firstName} {lastName}";
                log.LogInformation(currentEmailContent);
            }

            await messages.AddAsync(new CloudQueueMessage(currentEmailContent));

            watch.Stop();

            var elapsedInfo =
                $"Report and execution from Dynamics lasted for {watch.ElapsedMilliseconds} ms ({watch.Elapsed.Seconds} s) for user @{myCdsUserId}";
            log.LogInformation(elapsedInfo);
            return (ActionResult) new OkObjectResult(elapsedInfo);
        }
    }
}