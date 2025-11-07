using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Practicum_guide.Data;

var builder = FunctionsApplication.CreateBuilder(args);

builder.ConfigureFunctionsWebApplication();

// Application Insights isn't enabled by default. See https://aka.ms/AAt8mw4.
// builder.Services
//     .AddApplicationInsightsTelemetryWorkerService()
//     .ConfigureFunctionsApplicationInsights();

var host = new HostBuilder().ConfigureFunctionsWebApplication().ConfigureServices(services =>
{
    var cs = Environment.GetEnvironmentVariable("SqlConnection");
    if (string.IsNullOrWhiteSpace(cs))
    {
        Console.WriteLine("SqlConnection missing");
        throw new InvalidOperationException("SqlConnection not set.");
    }
    services.AddPooledDbContextFactory<DataContext>(o => o.UseSqlServer(cs));
    services.AddLogging();
}).Build();
host.Run();

builder.Build().Run();
