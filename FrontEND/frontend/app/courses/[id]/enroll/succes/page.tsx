"use client";

import { useEffect, useState } from "react";
import { useRouter } from "next/navigation";
import Link from "next/link";

const BASE_URL =
  process.env.NEXT_PUBLIC_API_BASE_URL || "http://localhost:5081/api";

export default function EnrollmentSuccessPage() {
  const router = useRouter();
  const [enrollmentStatus, setEnrollmentStatus] = useState<
    "loading" | "success" | "error"
  >("loading");

  useEffect(() => {
    const enrollUser = async () => {
      const userId = localStorage.getItem("userId");
      const selectedGroupString = localStorage.getItem("selectedGroup");
      if (!userId || !selectedGroupString) {
        console.error("Missing userId or selectedGroup", {
          userId,
          selectedGroupString,
        });
        setEnrollmentStatus("error");
        return;
      }

      const selectedGroup = JSON.parse(selectedGroupString);
      const grupaId = selectedGroup.grupaId;

      try {
        const response = await fetch(`${BASE_URL}/User/addGroups`, {
          method: "POST",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify({
            userId: Number.parseInt(userId),
            groupIds: [grupaId],
          }),
        });

        if (response.ok) {
          setEnrollmentStatus("success");
          // Clear the selectedGroup from localStorage after successful enrollment
          localStorage.removeItem("selectedGroup");
        } else {
          const errorData = await response.json();
          console.error("Failed to enroll user", errorData);
          throw new Error("Failed to enroll user");
        }
      } catch (error) {
        console.error("Error enrolling user:", error);
        setEnrollmentStatus("error");
      }
    };

    enrollUser();
  }, []);

  if (enrollmentStatus === "loading") {
    return (
      <div className="max-w-4xl mx-auto text-center">
        <h1 className="text-3xl font-bold mb-6">Finalizing Enrollment...</h1>
        <p className="text-xl mb-8">
          Please wait while we complete your enrollment.
        </p>
      </div>
    );
  }

  if (enrollmentStatus === "error") {
    return (
      <div className="max-w-4xl mx-auto text-center">
        <h1 className="text-3xl font-bold mb-6">Enrollment Error</h1>
        <p className="text-xl mb-8">
          We encountered an error while trying to complete your enrollment. The
          group information is missing. Please try again or contact support.
        </p>
        <Link
          href="/shop"
          className="inline-flex items-center px-4 py-2 border border-transparent text-sm font-medium rounded-md shadow-sm text-white bg-indigo-600 hover:bg-indigo-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500"
        >
          Return to Course Shop
        </Link>
      </div>
    );
  }

  return (
    <div className="max-w-4xl mx-auto text-center">
      <h1 className="text-3xl font-bold mb-6">Enrollment Successful!</h1>
      <p className="text-xl mb-8">
        Congratulations! You have successfully enrolled in the course and joined
        the selected group.
      </p>
      <Link
        href="/enrolled-courses"
        className="inline-flex items-center px-4 py-2 border border-transparent text-sm font-medium rounded-md shadow-sm text-white bg-indigo-600 hover:bg-indigo-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500"
      >
        View My Enrolled Courses
      </Link>
    </div>
  );
}
