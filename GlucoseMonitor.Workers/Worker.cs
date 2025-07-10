using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

using Azure.Storage.Queues;
using Newtonsoft.Json;

using GlucoseMonitor.Application.DTOs;
using GlucoseMonitor.Application.Validation; // <== voor MeasurementValidator
using GlucoseMonitor.Domain.Entities;
using GlucoseMonitor.Domain.Interfaces;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly QueueClient _queueClient;
    private readonly IMeasurementRepository _repository;
    private readonly IMeasurementProcessor _processor; // optioneel: logica om geldige metingen te verwerken

    public Worker(ILogger<Worker> logger, IConfiguration config, IMeasurementRepository repository, IMeasurementProcessor processor)
    {
        _logger = logger;
        _repository = repository;
        _processor = processor;

        _queueClient = new QueueClient(
            config["AzureStorage:ConnectionString"],
            config["AzureStorage:QueueName"]
        );

        _queueClient.CreateIfNotExists();
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("🔁 Worker gestart: wacht op queue-berichten");

        while (!stoppingToken.IsCancellationRequested)
        {
            var messages = await _queueClient.ReceiveMessagesAsync(maxMessages: 10, visibilityTimeout: TimeSpan.FromSeconds(30));

            foreach (var msg in messages.Value)
            {
                try
                {
                    var dto = JsonConvert.DeserializeObject<MeasurementDto>(msg.MessageText);
                    var measurement = new Measurement(dto.Id, dto.PatientId, dto.Value, dto.Unit, dto.Timestamp);

                    // ⏺ Altijd opslaan — ook als ongeldige of duplicate
                    await _repository.SaveAsync(measurement);
                    _logger.LogInformation($"💾 Measurement opgeslagen: {dto.Id}");

                    // 🧠 Valide data verwerken
                    if (MeasurementValidator.IsValid(measurement))
                    {
                        await _processor.ProcessAsync(measurement); // of analytics, alerts, etc.
                        _logger.LogInformation($"✅ Verwerkt: Measurement {dto.Id}");
                    }
                    else
                    {
                        _logger.LogWarning($"🚫 Ongeldig: Measurement {dto.Id} genegeerd bij verwerking.");
                    }

                    await _queueClient.DeleteMessageAsync(msg.MessageId, msg.PopReceipt);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"❌ Fout bij verwerking: {ex.Message}");
                }
            }

            await Task.Delay(2000, stoppingToken);
        }

        _logger.LogInformation("⏹ Worker gestopt.");
    }
}
