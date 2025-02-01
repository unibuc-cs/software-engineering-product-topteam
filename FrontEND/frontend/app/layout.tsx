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
    const userString = localStorage.getItem("user");

    console.log("Current pathname:", pathname);

    if (publicRoutes.includes(pathname)) {
      console.log("Accessing public route");
      return;
    }

    if (token && userString) {
      const user = JSON.parse(userString) as User;
      console.log("User data from localStorage:", user);
      setAuthState({ user, token });

      // Check if the user is trying to access a route they shouldn't
      if (
        (!user.profesorVerificat &&
          professorRoutes.some((route) => pathname.startsWith(route))) ||
        (user.profesorVerificat &&
          studentRoutes.some((route) => pathname.startsWith(route)))
      ) {
        const redirectPath = user.profesorVerificat
          ? "/professor/user"
          : "/shop";
        console.log("Redirecting to appropriate route:", redirectPath);
        router.push(redirectPath);
      }
    } else {
      console.log("No token or user data, redirecting to login");
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
