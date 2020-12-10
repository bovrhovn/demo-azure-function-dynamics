using System;
using Microsoft.PowerPlatform.Cds.Client;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Spectre.Console;

namespace DynamicsDemo.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            HorizontalRule("Getting data from CDS");
            var connString = Environment.GetEnvironmentVariable("CDSConnString");

            var svc = new CdsServiceClient(connString);
            var myCdsUserId = svc.GetMyCdsUserId();
            AnsiConsole.WriteLine("My user ID is " + myCdsUserId);

            HorizontalRule("Getting back account with primary contacts");

            var qe = new QueryExpression {EntityName = "account", ColumnSet = new ColumnSet()};
            qe.ColumnSet.Columns.Add("name");

            qe.LinkEntities.Add(new LinkEntity("account", "contact", "primarycontactid", "contactid",
                JoinOperator.Inner));
            qe.LinkEntities[0].Columns.AddColumns("firstname", "lastname");
            qe.LinkEntities[0].EntityAlias = "primarycontact";

            var ec = svc.RetrieveMultiple(qe);

            AnsiConsole.WriteLine($"Retrieved {ec.Entities.Count} entities");

            var projectRepresentation = new Table()
                .Border(TableBorder.Square)
                .BorderColor(Color.Red)
                .AddColumn(new TableColumn("Name"))
                .AddColumn(new TableColumn("First Name"))
                .AddColumn(new TableColumn("Last Name"));

            foreach (var act in ec.Entities)
            {
                var accountName = act["name"]?.ToString();
                var firstName = act.GetAttributeValue<AliasedValue>("primarycontact.firstname")?.Value?.ToString();
                var lastName = act.GetAttributeValue<AliasedValue>("primarycontact.lastname")?.Value?.ToString();

                projectRepresentation.AddRow(accountName ?? "", firstName ?? "", lastName ?? "");
            }

            AnsiConsole.Render(projectRepresentation);

            Console.WriteLine("Retrieved {0} entities", ec.Entities.Count);
        }

        private static void HorizontalRule(string title)
        {
            AnsiConsole.WriteLine();
            AnsiConsole.Render(new Rule($"[white bold]{title}[/]").RuleStyle("grey").LeftAligned());
            AnsiConsole.WriteLine();
        }
    }
}