using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.WebJobs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Shared.Data;
using Shared.Data.Entities;


namespace FunctionInjector1;

public class ProcessOrdersFromStorageQueue
{
    private readonly IDbContextFactory<AppDbContext> _ctxFactory;

    public ProcessOrdersFromStorageQueue(IDbContextFactory<AppDbContext> _ctxFactory)
        => _ctxFactory = _ctxFactory;


    [Function("ProcessOrdersFromStorageQueue")]
    public async Task Run(
    [Microsoft.Azure.Functions.Worker.QueueTrigger("%Storage:QueueName%", Connection = "StorageQueue")] byte[] message,
    FunctionContext context)
    {
        var log = context.GetLogger<ProcessOrdersFromStorageQueue>();
        var json = Encoding.UTF8.GetString(message);
        var dto = System.Text.Json.JsonSerializer.Deserialize<OrderEvent>(json);

        if (dto is null)
        {
            log.LogWarning("Invalid payload received.");
            return;
        }

        using var db = await _ctxFactory.CreateDbContextAsync();
        await db.OrderEvents.AddAsync(dto);

        await db.ProcessedOrders.AddAsync(new ProcessedOrder
        {
            OrderId = dto.OrderId,
            Amount = dto.Amount,
            Status = "Processed",
            ProcessedUtc = DateTime.UtcNow
        });

        await db.SaveChangesAsync();
        log.LogInformation("Processed (StorageQ) {OrderId}", dto.OrderId);
    }

}