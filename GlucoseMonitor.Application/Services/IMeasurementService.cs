using GlucoseMonitor.Application.DTOs;
using GlucoseMonitor.Domain.Entities;

namespace GlucoseMonitor.Application.Services
{
    public interface IMeasurementService
    {
        Task RegisterMeasurementAsync(MeasurementDto dto);
        Task<IEnumerable<AnomalyDto>> GetAnomaliesAsync(double lower, double upper);
        Task<IEnumerable<Measurement>> GetAllAsync();
    }
}
