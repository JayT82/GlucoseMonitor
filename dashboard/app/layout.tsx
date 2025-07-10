import type { Metadata } from "next";
import { Geist, Geist_Mono } from "next/font/google";
import "./globals.css";
import Navbar from "./components/Navbar";

export const metadata = {
  title: 'Glucose Dashboard',
};

export default function RootLayout({ children }: { children: React.ReactNode }) {
  return (
    <html lang="nl">
      <body className="bg-gray-100 text-gray-900">
        <Navbar />
        <main className="p-6 max-w-screen-lg mx-auto">{children}</main>
      </body>
    </html>
  );
}
