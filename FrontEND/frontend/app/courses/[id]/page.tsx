"use client";

import { useState, useEffect } from "react";
import { useRouter } from "next/navigation";
import { getCourse } from "../../lib/courseApi";
import { getUserEnrolledGroups } from "../../lib/userApi";
import type { Course } from "../../types/course";
import type { Group } from "../../types/group";

export default function CourseDetailsPage({
  params,
}: {
  params: { id: string };
}) {
  const [course, setCourse] = useState<Course | null>(null);
  const [enrolledGroup, setEnrolledGroup] = useState<Group | null>(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);
  const router = useRouter();

  useEffect(() => {
    async function fetchCourseAndEnrollmentStatus() {
      try {
        const [fetchedCourse, enrolledGroups] = await Promise.all([
          getCourse(Number.parseInt(params.id)),
          getUserEnrolledGroups(),
        ]);
        setCourse(fetchedCourse);
        const matchingGroup = enrolledGroups.find(
          (group) => group.cursId === fetchedCourse.cursId
        );
        setEnrolledGroup(matchingGroup || null);
        setLoading(false);
      } catch (err) {
        setError("Failed to load course details. Please try again later.");
        setLoading(false);
      }
    }

    fetchCourseAndEnrollmentStatus();
  }, [params.id]);

  const handleEnroll = () => {
    router.push(`/courses/${params.id}/enroll`);
  };

  if (loading) return <div>Loading course details...</div>;
  if (error) return <div className="text-red-500">{error}</div>;
  if (!course) return <div>Course not found</div>;

  return (
    <div className="max-w-4xl mx-auto">
      <h1 className="text-3xl font-bold mb-6">{course.denumire}</h1>
      <div className="bg-white shadow overflow-hidden sm:rounded-lg">
        <div className="px-4 py-5 sm:px-6">
          <h3 className="text-lg leading-6 font-medium text-gray-900">
            Course Details
          </h3>
        </div>
        <div className="border-t border-gray-200">
          <dl>
            <div className="bg-gray-50 px-4 py-5 sm:grid sm:grid-cols-3 sm:gap-4 sm:px-6">
              <dt className="text-sm font-medium text-gray-500">Description</dt>
              <dd className="mt-1 text-sm text-gray-900 sm:mt-0 sm:col-span-2">
                {course.descriere}
              </dd>
            </div>
            <div className="bg-white px-4 py-5 sm:grid sm:grid-cols-3 sm:gap-4 sm:px-6">
              <dt className="text-sm font-medium text-gray-500">
                Number of Sessions
              </dt>
              <dd className="mt-1 text-sm text-gray-900 sm:mt-0 sm:col-span-2">
                {course.nrSedinte}
              </dd>
            </div>
            <div className="bg-gray-50 px-4 py-5 sm:grid sm:grid-cols-3 sm:gap-4 sm:px-6">
              <dt className="text-sm font-medium text-gray-500">Price</dt>
              <dd className="mt-1 text-sm text-gray-900 sm:mt-0 sm:col-span-2">
                ${course.pret.toFixed(2)}
              </dd>
            </div>
            {enrolledGroup && (
              <div className="bg-white px-4 py-5 sm:grid sm:grid-cols-3 sm:gap-4 sm:px-6">
                <dt className="text-sm font-medium text-gray-500">
                  Meeting Link
                </dt>
                <dd className="mt-1 text-sm text-gray-900 sm:mt-0 sm:col-span-2">
                  <a
                    href={enrolledGroup.linkMeet}
                    target="_blank"
                    rel="noopener noreferrer"
                    className="text-blue-600 hover:text-blue-800"
                  >
                    Join Meeting
                  </a>
                </dd>
              </div>
            )}
          </dl>
        </div>
      </div>
      <div className="mt-6">
        {!enrolledGroup ? (
          <button
            onClick={handleEnroll}
            className="inline-flex items-center px-4 py-2 border border-transparent text-sm font-medium rounded-md shadow-sm text-white bg-indigo-600 hover:bg-indigo-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500"
          >
            Enroll in Course
          </button>
        ) : (
          <p className="text-green-600 font-semibold">
            You are enrolled in this course
          </p>
        )}
      </div>
    </div>
  );
}
