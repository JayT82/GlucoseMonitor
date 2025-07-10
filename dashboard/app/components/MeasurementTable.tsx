// app/components/MeasurementTable.tsx
type Measurement = {
  id: string;
  patientId: string;
  value: number;
  unit: string;
  timestamp: string;
};

export default function MeasurementTable({ data }: { data: Measurement[] }) {
  return (
    <table className="w-full bg-white shadow rounded overflow-hidden">
      <thead className="bg-gray-200">
        <tr>
          <th className="p-2">ID</th>
          <th className="p-2">Patiënt</th>
          <th className="p-2">Waarde</th>
          <th className="p-2">Tijdstip</th>
        </tr>
      </thead>
      <tbody>
        {data.map((m) => (
          <tr key={m.id} className="border-t">
            <td className="p-2">{m.id}</td>
            <td className="p-2">{m.patientId}</td>
            <td className="p-2">{m.value} {m.unit}</td>
            <td className="p-2">{new Date(m.timestamp).toLocaleString()}</td>
          </tr>
        ))}
      </tbody>
    </table>
  );
}
