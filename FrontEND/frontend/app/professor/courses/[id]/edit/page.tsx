"use client";

import { useState, useEffect } from "react";
import { useRouter } from "next/navigation";
import { getCourse, updateCourse } from "../../../../lib/courseApi";
import type { Course } from "../../../../types/course";

export default function EditCoursePage({ params }: { params: { id: string } }) {
  const [course, setCourse] = useState<Course | null>(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);
  const router = useRouter();

  useEffect(() => {
    async function fetchCourse() {
      try {
        const fetchedCourse = await getCourse(Number.parseInt(params.id));
        setCourse(fetchedCourse);
        setLoading(false);
      } catch (err) {
        setError("Failed to load course. Please try again later.");
        setLoading(false);
      }
    }

    fetchCourse();
  }, [params.id]);

  const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    if (!course) return;

    try {
      await updateCourse(course);
      router.push("/professor/courses");
    } catch (err) {
      setError("The course has been updated!");
    }
  };

  const handleInputChange = (
    e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>
  ) => {
    if (!course) return;
    const { name, value } = e.target;
    setCourse({
      ...course,
      [name]:
        name === "pret" || name === "nrSedinte"
          ? Number.parseFloat(value)
          : value,
    });
  };

  if (loading) return <div>Loading course...</div>;
  if (error) return <div className="text-red-500">{error}</div>;
  if (!course) return <div>Course not found</div>;

  return (
    <div className="max-w-4xl mx-auto">
      <h1 className="text-3xl font-bold mb-6">Edit Course</h1>
      <form onSubmit={handleSubmit} className="space-y-4">
        <div>
          <label
            htmlFor="denumire"
            className="block text-sm font-medium text-gray-700"
          >
            Course Name
          </label>
          <input
            type="text"
            id="denumire"
            name="denumire"
            value={course.denumire}
            onChange={handleInputChange}
            className="mt-1 block w-full rounded-md border-gray-300 shadow-sm focus:border-indigo-300 focus:ring focus:ring-indigo-200 focus:ring-opacity-50"
            required
          />
        </div>
        <div>
          <label
            htmlFor="descriere"
            className="block text-sm font-medium text-gray-700"
          >
            Description
          </label>
          <textarea
            id="descriere"
            name="descriere"
            value={course.descriere}
            onChange={handleInputChange}
            rows={4}
            className="mt-1 block w-full rounded-md border-gray-300 shadow-sm focus:border-indigo-300 focus:ring focus:ring-indigo-200 focus:ring-opacity-50"
            required
          ></textarea>
        </div>
        <div>
          <label
            htmlFor="nrSedinte"
            className="block text-sm font-medium text-gray-700"
          >
            Number of Sessions
          </label>
          <input
            type="number"
            id="nrSedinte"
            name="nrSedinte"
            value={course.nrSedinte}
            onChange={handleInputChange}
            className="mt-1 block w-full rounded-md border-gray-300 shadow-sm focus:border-indigo-300 focus:ring focus:ring-indigo-200 focus:ring-opacity-50"
            required
            min="1"
          />
        </div>
        <div>
          <label
            htmlFor="pret"
            className="block text-sm font-medium text-gray-700"
          >
            Price
          </label>
          <input
            type="number"
            id="pret"
            name="pret"
            value={course.pret}
            onChange={handleInputChange}
            className="mt-1 block w-full rounded-md border-gray-300 shadow-sm focus:border-indigo-300 focus:ring focus:ring-indigo-200 focus:ring-opacity-50"
            required
            min="0"
            step="0.01"
          />
        </div>
        <div className="flex justify-end space-x-3">
          <button
            type="button"
            onClick={() => router.back()}
            className="px-4 py-2 border border-gray-300 rounded-md shadow-sm text-sm font-medium text-gray-700 hover:bg-gray-50 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500"
          >
            Cancel
          </button>
          <button
            type="submit"
            className="px-4 py-2 border border-transparent rounded-md shadow-sm text-sm font-medium text-white bg-indigo-600 hover:bg-indigo-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500"
          >
            Save Changes
          </button>
        </div>
      </form>
    </div>
  );
}
