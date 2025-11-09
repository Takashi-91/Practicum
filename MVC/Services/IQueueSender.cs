namespace MVC
{

    public interface IQueueSender 
    { Task SendAsync(string queueName, string json); }
}
