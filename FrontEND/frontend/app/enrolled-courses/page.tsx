"use client";

import { useState, useEffect } from "react";
import Link from "next/link";
import Image from "next/image";
import type { Course } from "../types/course";
import type { Group } from "../types/group";

interface EnrolledGroup extends Group {
  curs: Course | null;
}

export default function EnrolledCoursesPage() {
  const [enrolledGroups, setEnrolledGroups] = useState<EnrolledGroup[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);
  const API_BASE_URL = "http://localhost:5081/api";

  useEffect(() => {
    async function fetchEnrolledCourses() {
      try {
        const userId = localStorage.getItem("userId");
        if (!userId) {
          throw new Error("User ID not found");
        }

        // First, get all groups the student is enrolled in
        const groupsResponse = await fetch(
          `${API_BASE_URL}/User/getAddedGroups?id=${userId}`
        );
        if (!groupsResponse.ok) {
          throw new Error("Failed to fetch enrolled groups");
        }
        const groups: EnrolledGroup[] = await groupsResponse.json();

        // Then, for each group, fetch the corresponding course
        const groupsWithCourses = await Promise.all(
          groups.map(async (group) => {
            const courseResponse = await fetch(
              `${API_BASE_URL}/Curs/${group.cursId}`
            );
            if (courseResponse.ok) {
              const course = await courseResponse.json();
              return { ...group, curs: course };
            }
            return { ...group, curs: null };
          })
        );

        setEnrolledGroups(groupsWithCourses);
        setLoading(false);
      } catch (err) {
        console.error("Error fetching enrolled courses:", err);
        setError(
          "Failed to load your enrolled courses. Please try again later."
        );
        setLoading(false);
      }
    }

    fetchEnrolledCourses();
  }, []);

  if (loading) {
    return (
      <div className="max-w-6xl mx-auto p-6">
        <div className="text-center">Loading your enrolled courses...</div>
      </div>
    );
  }

  if (error) {
    return (
      <div className="max-w-6xl mx-auto p-6">
        <div className="text-red-500 text-center">{error}</div>
      </div>
    );
  }

  if (enrolledGroups.length === 0) {
    return (
      <div className="max-w-6xl mx-auto p-6 text-center">
        <h1 className="text-3xl font-bold mb-6">Enrolled Courses</h1>
        <p className="text-xl text-gray-600 mb-4">
          You haven't enrolled in any courses yet.
        </p>
        <Link
          href="/shop"
          className="inline-block bg-blue-500 text-white px-6 py-2 rounded hover:bg-blue-600 transition duration-300"
        >
          Browse Courses
        </Link>
      </div>
    );
  }

  return (
    <div className="max-w-6xl mx-auto p-6">
      <h1 className="text-3xl font-bold mb-8">Enrolled Courses</h1>
      <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-8">
        {enrolledGroups.map((group) => (
          <Link href={`/courses/${group.cursId}`} key={group.id}>
            <div className="bg-white rounded-lg overflow-hidden shadow-lg hover:shadow-xl transition duration-300">
              {group.curs ? (
                <>
                  <Image
                    src="/placeholder.svg"
                    alt={group.curs.denumire}
                    width={400}
                    height={200}
                    className="w-full h-48 object-cover"
                  />
                  <div className="p-6">
                    <h2 className="text-xl font-semibold mb-2 text-gray-800">
                      {group.curs.denumire}
                    </h2>
                    <p className="text-gray-600 mb-4 line-clamp-2">
                      {group.curs.descriere}
                    </p>
                    <div className="space-y-2">
                      <p className="text-sm text-gray-500">
                        <strong>Group:</strong> {group.nume}
                      </p>
                      <p className="text-sm text-gray-500">
                        <strong>Study Level:</strong> {group.nivelStudiu}
                      </p>
                      <p className="text-sm text-gray-500">
                        <strong>Number of Sessions:</strong>{" "}
                        {group.curs.nrSedinte}
                      </p>
                    </div>
                  </div>
                </>
              ) : (
                <div className="p-6">
                  <h2 className="text-xl font-semibold mb-2 text-gray-800">
                    Group: {group.nume}
                  </h2>
                  <p className="text-red-500">Course details unavailable</p>
                </div>
              )}
            </div>
          </Link>
        ))}
      </div>
    </div>
  );
}
