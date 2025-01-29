"use client";

import { Inter } from "next/font/google";
import { useEffect, useState } from "react";
import { useRouter, usePathname } from "next/navigation";
import { Navbar } from "./components/Navbar";
import { getUserFromToken } from "./lib/auth";
import type { AuthState, User } from "./types/auth";
import "./globals.css";

const inter = Inter({ subsets: ["latin"] });

const studentRoutes = ["/shop", "/enrolled-courses", "/homework"];
const professorRoutes = [
  "/professor/user",
  "/professor/courses",
  "/professor/assign-homework",
];

export default function RootLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  const [authState, setAuthState] = useState<AuthState>({
    user: null,
    token: null,
  });
  const router = useRouter();
  const pathname = usePathname();

  useEffect(() => {
    const token = localStorage.getItem("authToken");
    const role = localStorage.getItem("userRole") as User["role"] | null;

    if (token && role) {
      const user = getUserFromToken(token);
      if (user) {
        setAuthState({ user: { ...user, role }, token });

        // Check if the user is trying to access a route they shouldn't
        if (
          (role === "student" &&
            professorRoutes.some((route) => pathname.startsWith(route))) ||
          (role === "professor" &&
            studentRoutes.some((route) => pathname.startsWith(route)))
        ) {
          router.push(role === "student" ? "/shop" : "/professor/user");
        }
      } else {
        // Invalid token, redirect to login
        router.push("/login");
      }
    } else if (!["/login", "/register"].includes(pathname)) {
      router.push("/login");
    }
  }, [pathname, router]);

  return (
    <html lang="en">
      <body className={inter.className}>
        <div className="flex h-screen bg-gray-100">
          {authState.user && <Navbar user={authState.user} />}
          <main className="flex-1 p-8 overflow-auto">{children}</main>
        </div>
      </body>
    </html>
  );
}
