"use client";

import { useState, useEffect } from "react";
import Link from "next/link";
import type { Course } from "../types/course";
import { getAllCourses } from "../lib/courseApi";

export default function ShopPage() {
  const [courses, setCourses] = useState<Course[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    async function fetchCourses() {
      try {
        const allCourses = await getAllCourses();
        setCourses(allCourses);
        setLoading(false);
      } catch (err) {
        setError("Failed to load courses. Please try again later.");
        setLoading(false);
      }
    }

    fetchCourses();
  }, []);

  if (loading) {
    return <div>Loading courses...</div>;
  }

  if (error) {
    return <div className="text-red-500">{error}</div>;
  }

  return (
    <div className="max-w-6xl mx-auto">
      <h1 className="text-3xl font-bold mb-6">Available Courses</h1>
      <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
        {courses.map((course) => (
          <div
            key={course.cursId}
            className="border rounded-lg p-4 hover:shadow-lg transition duration-300"
          >
            <h2 className="text-xl font-semibold mb-2">{course.denumire}</h2>
            <p className="text-gray-600 mb-2 line-clamp-3">
              {course.descriere}
            </p>
            <p className="text-blue-600 font-bold">${course.pret.toFixed(2)}</p>
            <p className="text-sm text-gray-500 mt-2">
              Number of sessions: {course.nrSedinte}
            </p>
            <Link
              href={`/courses/${course.cursId}`}
              className="mt-4 inline-block bg-blue-500 text-white px-4 py-2 rounded hover:bg-blue-600 transition duration-300"
            >
              View Details
            </Link>
          </div>
        ))}
      </div>
    </div>
  );
}
