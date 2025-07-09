namespace GlucoseMonitor.Application.DTOs
{
    public class AnomalyDto
    {
        public string AnomalyId { get; set; }
        public string MeasurementId { get; set; }
        public string PatientId { get; set; }
        public string MeasurementType { get; set; } = "blood_glucose";
        public double Value { get; set; }
        public string Unit { get; set; }
        public DateTime Timestamp { get; set; }
        public string ThresholdType { get; set; } // "low" of "high"
        public double ThresholdValue { get; set; }
    }
}
