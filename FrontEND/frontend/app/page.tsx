"use client";

import { useEffect, useState } from "react";
import { useRouter, useSearchParams } from "next/navigation";
import { getUserFromToken } from "./lib/auth";
import { Notification } from "./components/Notification";

export default function Home() {
  const router = useRouter();
  const searchParams = useSearchParams();
  const [showLogoutNotification, setShowLogoutNotification] = useState(false);

  useEffect(() => {
    const token = localStorage.getItem("authToken");
    const role = localStorage.getItem("userRole");

    if (searchParams.get("logout") === "success") {
      setShowLogoutNotification(true);
    }

    if (token && role) {
      const user = getUserFromToken(token);
      if (user) {
        router.push(role === "student" ? "/shop" : "/professor/user");
      } else {
        router.push("/login");
      }
    } else {
      router.push("/login");
    }
  }, [router, searchParams]);

  return (
    <>
      {showLogoutNotification && (
        <Notification
          message="You have been logged out successfully."
          type="success"
        />
      )}
    </>
  );
}
