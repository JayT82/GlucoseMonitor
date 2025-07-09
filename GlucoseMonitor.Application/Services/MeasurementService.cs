using GlucoseMonitor.Application.DTOs;
using GlucoseMonitor.Domain.Entities;
using GlucoseMonitor.Domain.Interfaces;
using GlucoseMonitor.Domain.ValueObjects;

namespace GlucoseMonitor.Application.Services
{
    public class MeasurementService : IMeasurementService
    {
        private readonly IMeasurementRepository _repository;

        public MeasurementService(IMeasurementRepository repository)
        {
            _repository = repository;
        }

        public async Task RegisterMeasurementAsync(MeasurementDto dto)
        {
            var value = new MeasurementValue(dto.Value, dto.Unit);
            var measurement = new Measurement(dto.Id, dto.PatientId, dto.Value,dto.Unit, dto.Timestamp);

            await _repository.SaveAsync(measurement);
        }

        public async Task<IEnumerable<AnomalyDto>> GetAnomaliesAsync(double lower, double upper)
        {
            var all = await _repository.GetAllAsync();

            var anomalies = all
                .Where(m => m.IsAnomaly(lower, upper))
                .Select(m => new AnomalyDto
                {
                    MeasurementId = m.Id,
                    PatientId = m.PatientId,
                    Value = m.Value,
                    Unit = m.Unit,
                    Timestamp = m.Timestamp,
                    ThresholdType = m.Value < lower ? "low" : "high",
                    ThresholdValue = m.Value < lower ? lower : upper
                });

            return anomalies;
        }
    }
}
