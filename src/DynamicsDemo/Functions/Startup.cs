using System;
using Functions;
using Functions.Interfaces;
using Functions.Services;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Startup))]
namespace Functions
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddScoped<IStorageWorker, AzureStorageWorker>(_ =>
                new AzureStorageWorker(Environment.GetEnvironmentVariable("StorageKey"),
                    Environment.GetEnvironmentVariable("ContainerName")));
        }
    }
}