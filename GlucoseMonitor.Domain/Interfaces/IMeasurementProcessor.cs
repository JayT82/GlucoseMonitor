using GlucoseMonitor.Domain.Entities;
using System.Threading.Tasks;
namespace GlucoseMonitor.Domain.Interfaces
{
    public interface IMeasurementProcessor
    {
        Task ProcessAsync(Measurement measurement);
    }
}