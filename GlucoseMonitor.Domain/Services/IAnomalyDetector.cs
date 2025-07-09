using GlucoseMonitor.Domain.Entities;
using System.Collections.Generic;

namespace GlucoseMonitor.Domain.Services
{
    public interface IAnomalyDetector
    {
        IEnumerable<Measurement> DetectAnomalies(IEnumerable<Measurement> measurements, double lowerThreshold, double upperThreshold);
    }
}