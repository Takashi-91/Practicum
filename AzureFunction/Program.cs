using System;
using Library.Data;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureAppConfiguration(cfg =>
    {
        cfg.AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
           .AddEnvironmentVariables();
    })
    .ConfigureFunctionsWebApplication()
    .ConfigureServices((ctx, services) =>
    {
        var cfg = ctx.Configuration;
        var sql = cfg.GetConnectionString("RealTimeDb") ?? cfg["SqlConnection"];
        services.AddDbContextFactory<LibraryDbContext>(opt => opt.UseSqlServer(sql));
    })
    .Build();

await host.RunAsync();
