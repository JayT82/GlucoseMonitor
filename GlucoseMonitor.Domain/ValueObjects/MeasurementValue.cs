using GlucoseMonitor.Domain.Exceptions;

namespace GlucoseMonitor.Domain.ValueObjects
{
    public class MeasurementValue
    {
        public double Value { get; }
        public string Unit { get; }

        public MeasurementValue(double value, string unit)
        {
            if (value <= 0) throw new InvalidMeasurementException("Waarde moet positief zijn.");
            if (unit != "mmol/l") throw new InvalidMeasurementException("Enkel mmol/l ondersteund.");

            Value = value;
            Unit = unit;
        }
    }
}
