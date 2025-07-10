using System.Threading.Tasks;
using GlucoseMonitor.Domain.Entities;
using GlucoseMonitor.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace GlucoseMonitor.Application.Services
{
    public class MeasurementProcessor : IMeasurementProcessor
    {
        private readonly ILogger<MeasurementProcessor> _logger;

        public MeasurementProcessor(ILogger<MeasurementProcessor> logger)
        {
            _logger = logger;
        }

        public async Task ProcessAsync(Measurement measurement)
        {
            // Simpele voorbeeldverwerking: detecteer hoge waarde
            if (measurement.Value > 20)
            {
                _logger.LogWarning($"🚨 Hoge glucosewaarde gedetecteerd: {measurement.Value} bij patiënt {measurement.PatientId}");
                // Eventueel notificatie of aparte opslag
            }
            else
            {
                _logger.LogInformation($"📊 Normale verwerking: {measurement.Value} mmol/L voor {measurement.PatientId}");
            }

            await Task.CompletedTask;
        }
    }
}
