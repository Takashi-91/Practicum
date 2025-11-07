using ECommerceClassLibrary;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.WebJobs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Practicum_guide.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FunctionInjester
{
    public class IngestEvents
    {
        private readonly IDbContextFactory<DataContext> dbContextFactory;
        public IngestEvents(IDbContextFactory<DataContext> dbContext) => dbContextFactory = dbContext;

        [FunctionName("IngestEvents")]
        public async Task Run(
            [QueueTrigger("events-queue")] string raw,
            ILogger log)
        {
            await using var db = await dbContextFactory.CreateDbContextAsync();
            try
            {
                var r = JsonDocument.Parse(raw).RootElement;
                var entity = new Event
                {
                    EventId = r.GetProperty("eventId").GetGuid(),
                    EventType = r.GetProperty("type").GetString() ?? "Unknown",
                    Payload = raw,
                    Occurred = r.GetProperty("occuredAt").GetDateTime(),
                    SessionId = r.TryGetProperty("sessionId", out var s) ? s.GetString() : null,
                    CustomerId = r.TryGetProperty("customerId", out var c) ? c.GetString() : null
                };
                db.Events.Add(entity);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                log.LogError(ex, "Bad Message: {raw}", raw);

                throw;
            }
        }
       
    }
}
