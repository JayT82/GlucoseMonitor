using System;

namespace GlucoseMonitor.Domain.Exceptions
{
    public class InvalidMeasurementException : Exception
    {
        public InvalidMeasurementException() : base("De meting is ongeldig.") { }

        public InvalidMeasurementException(string message) : base(message) { }

        public InvalidMeasurementException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}