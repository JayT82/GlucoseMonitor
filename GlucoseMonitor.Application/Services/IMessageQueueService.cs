namespace GlucoseMonitor.Application.Services
{
    public interface IMessageQueueService
    {
        Task SendMessageAsync(string message);
    }
}