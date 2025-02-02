"use client";

import { useEffect, useState } from "react";
import { useRouter } from "next/navigation";
import { getUserById } from "./lib/auth";
import { Notification } from "./components/Notification";
import type { User } from "./types/auth";

export default function Home() {
  const router = useRouter();
  const [showLogoutNotification, setShowLogoutNotification] = useState(false);
  const [user, setUser] = useState<User | null>(null);

  useEffect(() => {
    const token = localStorage.getItem("authToken");
    const userId = localStorage.getItem("userId");

    if (token && userId) {
      getUserById(Number.parseInt(userId), token)
        .then((userData) => {
          if (userData) {
            setUser(userData);
            localStorage.setItem("userNivel", userData.nivel);
            router.push(
              userData.nivel === "student" ? "/shop" : "/professor/user"
            );
          } else {
            // If user data couldn't be fetched, redirect to login
            router.push("/login");
          }
        })
        .catch((error) => {
          console.error("Error fetching user data:", error);
          router.push("/login");
        });
    } else {
      router.push("/login");
    }

    // Check for logout notification
    const params = new URLSearchParams(window.location.search);
    if (params.get("logout") === "success") {
      setShowLogoutNotification(true);
    }
  }, [router]);

  return (
    <div className="flex flex-col items-center justify-center min-h-screen py-2">
      <main className="flex flex-col items-center justify-center w-full flex-1 px-20 text-center">
        <h1 className="text-6xl font-bold">Welcome to the Course Website</h1>
        {user ? (
          <p className="mt-3 text-2xl">
            Hello, {user.prenume} {user.nume}!
          </p>
        ) : (
          <p className="mt-3 text-2xl">Loading...</p>
        )}
      </main>

      {showLogoutNotification && (
        <Notification
          message="You have been logged out successfully."
          type="success"
        />
      )}
    </div>
  );
}
