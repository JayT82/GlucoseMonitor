using System.Text.Json.Serialization;

namespace GlucoseMonitor.Application.DTOs
{
    public class MeasurementDto
    {
        [JsonPropertyName("measurement_id")]
        public string Id { get; set; }

        [JsonPropertyName("patient_id")]
        public string PatientId { get; set; }

        [JsonPropertyName("value")]
        public double Value { get; set; }

        [JsonPropertyName("unit")]
        public string Unit { get; set; }

        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonPropertyName("measurement_type")]
        public string Type { get; set; } = "blood_glucose";  // standaardwaarde
    }
}
