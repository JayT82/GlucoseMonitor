// app/page.tsx
export default function HomePage() {
  return (
    <section>
      <h1 className="text-3xl font-bold">Glucose Monitor 📋</h1>
      <p className="mt-2">Welkom! Ga naar je <a href="/dashboard" className="text-blue-500 underline">dashboard</a> om metingen te bekijken.</p>
    </section>
  );
}
