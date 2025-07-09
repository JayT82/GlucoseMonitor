using GlucoseMonitor.Domain.Entities;
using GlucoseMonitor.Domain.Interfaces;

namespace GlucoseMonitor.Infrastructure.Messaging
{
    public class QueueService : IMeasurementQueue
    {
        private readonly List<Measurement> _queue = new();

        public Task EnqueueAsync(Measurement measurement)
        {
            // Simuleer een queue door het lokaal op te slaan
            _queue.Add(measurement);
            Console.WriteLine($"[QueueService] Measurement {measurement.Id} toegevoegd aan queue.");
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Measurement>> DequeueAllAsync()
        {
            var copy = _queue.ToList();
            _queue.Clear();
            return Task.FromResult<IEnumerable<Measurement>>(copy);
        }
    }
}
