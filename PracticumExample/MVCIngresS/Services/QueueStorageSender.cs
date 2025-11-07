using System.Text;
using Azure.Storage.Queues;

namespace MVCIngress.Services
{
    public class QueueStorageSender : IQueueSender
    {
        private readonly QueueServiceClient _svc;
        public QueueStorageSender(QueueServiceClient svc)

        {  _svc = svc; 
        }
      

        public async Task SendAsync(string queueName, string json)
        {
            var q = _svc.GetQueueClient(queueName);
            await q.CreateIfNotExistsAsync();
            await q.SendMessageAsync(Convert.ToBase64String(Encoding.UTF8.GetBytes(json)));
        }
    }
}
