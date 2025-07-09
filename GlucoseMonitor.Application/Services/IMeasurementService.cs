using GlucoseMonitor.Application.DTOs;

namespace GlucoseMonitor.Application.Services
{
    public interface IMeasurementService
    {
        Task RegisterMeasurementAsync(MeasurementDto dto);
        Task<IEnumerable<AnomalyDto>> GetAnomaliesAsync(double lower, double upper);
    }
}
