using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shared.Data;

var builder = FunctionsApplication.CreateBuilder(args);

builder.Configuration["Functions:Worker:HostEndpoint"] = "http://localhost:12345";

var conn =builder.Configuration.GetConnectionString("RealTimeDb");

builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer(conn));

builder.ConfigureFunctionsWebApplication();

builder.Services
    .AddApplicationInsightsTelemetryWorkerService()
    .ConfigureFunctionsApplicationInsights();

builder.Build().Run();
