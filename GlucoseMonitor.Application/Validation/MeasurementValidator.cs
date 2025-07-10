
using GlucoseMonitor.Domain.Entities;

namespace GlucoseMonitor.Application.Validation
{
    

    public static class MeasurementValidator
    {
        public static bool IsValid(Measurement m)
        {
            if (m == null) return false;

            var valueIsValid = m.Value > 0 && m.Value < 50; // medische grens, aanpasbaar
            var unitIsValid = m.Unit == "mmol/L" || m.Unit == "mg/dL";
            var timestampIsValid = m.Timestamp > DateTime.MinValue;
            var patientIsValid = !string.IsNullOrWhiteSpace(m.PatientId);

            return valueIsValid && unitIsValid && timestampIsValid && patientIsValid;
        }
    }

}
