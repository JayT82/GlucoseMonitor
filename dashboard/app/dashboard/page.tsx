'use client';

import { useEffect, useState } from 'react';

export default function DashboardPage() {
  const [data, setData] = useState([]);
  const [error, setError] = useState('');

  useEffect(() => {
    fetch('https://localhost:7124/api/Measurements/measurements')
      .then((res) => {
        if (!res.ok) throw new Error('Netwerkfout');
        return res.json();
      })
      .then(setData)
      .catch((err) => {
        console.error('❌ Fetch error:', err);
        setError('Kan data niet ophalen');
      });
  }, []);

  if (error) return <p>{error}</p>;
  if (!data.length) return <p>⏳ Laden...</p>;

  return (
    <div>
      <h2>📊 Glucosemetingen</h2>
      <ul>
        {data.map((m: any) => (
          <li key={m.id}>
            {m.patientId} → {m.value} {m.unit} op {new Date(m.timestamp).toLocaleString()}
          </li>
        ))}
      </ul>
    </div>
  );
}
