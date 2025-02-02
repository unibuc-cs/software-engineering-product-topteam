"use client";

import { Inter } from "next/font/google";
import { useEffect, useState } from "react";
import { useRouter, usePathname } from "next/navigation";
import { Navbar } from "./components/Navbar";
import type { AuthState, User } from "./types/auth";
import "./globals.css";
import type React from "react";

const inter = Inter({ subsets: ["latin"] });

const publicRoutes = ["/login", "/register"];
const studentRoutes = ["/shop", "/enrolled-courses", "/homework", "/user"];
const professorRoutes = [
  "/professor/user",
  "/professor/courses",
  "/professor/assign-homework",
  "/professor/create-course",
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
    const userId = localStorage.getItem("userId");
    const userNivel = localStorage.getItem("userNivel");

    if (publicRoutes.includes(pathname)) {
      // Allow access to public routes without authentication
      return;
    }

    if (token && userId && userNivel) {
      setAuthState({
        user: { id: Number.parseInt(userId), nivel: userNivel } as User,
        token,
      });

      // Check if the user is trying to access a route they shouldn't
      if (
        (userNivel === "student" &&
          professorRoutes.some((route) => pathname.startsWith(route))) ||
        (userNivel === "profesor" &&
          studentRoutes.some((route) => pathname.startsWith(route)))
      ) {
        router.push(userNivel === "student" ? "/shop" : "/professor/user");
      }
    } else {
      // No token or user info, redirect to login for protected routes
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
