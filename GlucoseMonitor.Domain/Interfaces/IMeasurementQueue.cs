using GlucoseMonitor.Domain.Entities;

namespace GlucoseMonitor.Domain.Interfaces
{
    public interface IMeasurementQueue
    {
        Task EnqueueAsync(Measurement measurement);
        Task<IEnumerable<Measurement>> DequeueAllAsync();
    }
}
