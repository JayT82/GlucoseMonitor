using GlucoseMonitor.Domain.Exceptions;
using GlucoseMonitor.Domain.ValueObjects;

namespace GlucoseMonitor.Domain.Entities
{
    public class Measurement
    {
        public string Id { get; private set; }
        public string PatientId { get; private set; }
        public string Type { get; private set; }
        public double Value { get; private set; }
        public string Unit { get; private set; }
        public DateTime Timestamp { get; private set; }

        public Measurement(string id, string patientId, double value, string unit, DateTime timestamp)
        {
            Id = id;
            PatientId = patientId;
            Value = value;
            Unit = unit;
            Timestamp = timestamp;
            Type = "blood_glucose";
        }

        public bool IsAnomaly(double min, double max) => Value < min || Value > max;
    }
}

    
