// app/components/Navbar.tsx
import Link from 'next/link';

export default function Navbar() {
  return (
    <nav className="bg-white shadow p-4 flex gap-4">
      <Link href="/">🏠 Home</Link>
      <Link href="/dashboard">📈 Dashboard</Link>
    </nav>
  );
}
