"use client";

import { useState, useEffect } from "react";
import Link from "next/link";
import type { Course } from "../../types/course";
import { getAllCourses } from "../../lib/courseApi";
import { getAllGroups } from "../../lib/groupApi";
import { Edit, Trash } from "lucide-react";

export default function ProfessorCoursesPage() {
  const [courses, setCourses] = useState<Course[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    async function fetchProfessorCourses() {
      try {
        const [allCourses, allGroups] = await Promise.all([
          getAllCourses(),
          getAllGroups(),
        ]);
        const userProfesorId = Number(localStorage.getItem("userId"));

        const professorGroupIds = allGroups
          .filter((group) => group.userProfesorId === userProfesorId)
          .map((group) => group.cursId);

        const professorCourses = allCourses.filter((course) =>
          professorGroupIds.includes(course.cursId)
        );

        setCourses(professorCourses);
        setLoading(false);
      } catch (err) {
        setError("Failed to load courses. Please try again later.");
        setLoading(false);
      }
    }

    fetchProfessorCourses();
  }, []);

  if (loading) {
    return <div>Loading courses...</div>;
  }

  if (error) {
    return <div className="text-red-500">{error}</div>;
  }

  return (
    <div className="max-w-6xl mx-auto">
      <h1 className="text-3xl font-bold mb-6">Your Created Courses</h1>
      <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
        {courses.map((course) => (
          <div
            key={course.cursId}
            className="border rounded-lg p-4 hover:shadow-lg transition duration-300"
          >
            <h2 className="text-xl font-semibold mb-2">{course.denumire}</h2>
            <p className="text-gray-600 mb-2">{course.descriere}</p>
            <p className="text-blue-600 font-bold">${course.pret.toFixed(2)}</p>
            <p className="text-sm text-gray-500 mt-2">
              Number of sessions: {course.nrSedinte}
            </p>
            <div className="mt-4 flex justify-between">
              <Link
                href={`/professor/courses/${course.cursId}/edit`}
                className="inline-flex items-center px-3 py-2 border border-transparent text-sm leading-4 font-medium rounded-md text-white bg-indigo-600 hover:bg-indigo-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500"
              >
                <Edit className="h-4 w-4 mr-2" />
                Edit
              </Link>
              <button
                onClick={() => {
                  /* Implement delete functionality */
                }}
                className="inline-flex items-center px-3 py-2 border border-transparent text-sm leading-4 font-medium rounded-md text-white bg-red-600 hover:bg-red-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-red-500"
              >
                <Trash className="h-4 w-4 mr-2" />
                Delete
              </button>
            </div>
          </div>
        ))}
      </div>
    </div>
  );
}
