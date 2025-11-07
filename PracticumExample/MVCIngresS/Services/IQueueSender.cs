namespace MVCIngress.Services
{
    public interface IQueueSender { Task SendAsync(string queueName, string json); }
}
