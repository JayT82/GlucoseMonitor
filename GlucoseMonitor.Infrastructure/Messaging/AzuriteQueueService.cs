using Azure.Storage.Queues;
using GlucoseMonitor.Application.Services;
using Microsoft.Extensions.Configuration;

public class AzuriteQueueService : IMessageQueueService
{
    private readonly QueueClient _queueClient;

    public AzuriteQueueService(IConfiguration config)
    {
        _queueClient = new QueueClient(
            config["AzureStorage:ConnectionString"],
            config["AzureStorage:QueueName"]
        );
        _queueClient.CreateIfNotExists();
    }

    public async Task SendMessageAsync(string message)
    {
        await _queueClient.SendMessageAsync(message);
    }
}