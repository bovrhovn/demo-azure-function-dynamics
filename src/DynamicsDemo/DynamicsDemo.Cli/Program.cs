using Microsoft.PowerPlatform.Cds.Client;
using Spectre.Console;

namespace DynamicsDemo.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            HorizontalRule("Getting data from CDS");
            //string connString = "AuthType=Office365;Username=admin@M365B537047.onmicrosoft.com;Password=7n8R2zNpZV;Url=https://m365b537047.crm.dynamics.com/";
            var connString = "AuthType=OAuth;Username=admin@M365B537047.onmicrosoft.com;Password=7n8R2zNpZV;Url=https://m365b537047.crm.dynamics.com;AppId=e8461075-fab8-43f0-9c13-a4c60c97bdd5;RedirectUri=http://localhost;ClientId=e8461075-fab8-43f0-9c13-a4c60c97bdd5;ClientSecret=t~4Jcn4cpL.X0L700BTpwa~6hdcRJ.tk6f;LoginPrompt=Auto";

            var svc = new CdsServiceClient(connString);
            var myCdsUserId = svc.GetMyCdsUserId();
            AnsiConsole.WriteLine("My user ID is " + myCdsUserId);
        }

        private static void HorizontalRule(string title)
        {
            AnsiConsole.WriteLine();
            AnsiConsole.Render(new Rule($"[white bold]{title}[/]").RuleStyle("grey").LeftAligned());
            AnsiConsole.WriteLine();
        }
    }
}