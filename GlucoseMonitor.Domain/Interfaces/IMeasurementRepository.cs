using GlucoseMonitor.Domain.Entities;

namespace GlucoseMonitor.Domain.Interfaces
{
    public interface IMeasurementRepository
    {
        Task SaveAsync(Measurement measurement);
        Task<IEnumerable<Measurement>> GetAllAsync();
        Task<IEnumerable<Measurement>> GetAnomaliesAsync(double lowerBound, double upperBound);
    }
}