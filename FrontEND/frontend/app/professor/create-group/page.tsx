"use client";

import { useState, useEffect } from "react";
import { useRouter } from "next/navigation";
import { createGroup } from "../../lib/groupApi";
import { getAllCourses } from "../../lib/courseApi";
import type { Course } from "../../types/course";
import { Plus } from "lucide-react";

export default function CreateGroupPage() {
  const [nume, setNume] = useState("");
  const [nivelStudiu, setNivelStudiu] = useState("");
  const [linkMeet, setLinkMeet] = useState("");
  const [cursId, setCursId] = useState("");
  const [courses, setCourses] = useState<Course[]>([]);
  const router = useRouter();

  useEffect(() => {
    async function fetchCourses() {
      try {
        const fetchedCourses = await getAllCourses();
        setCourses(fetchedCourses);
      } catch (error) {
        console.error("Failed to fetch courses:", error);
      }
    }
    fetchCourses();
  }, []);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const userProfesorId = Number(localStorage.getItem("userId"));
      const newGroup = await createGroup({
        nume,
        nivelStudiu,
        linkMeet,
        userProfesorId,
        cursId: Number(cursId),
        userEleviId: null,
      });
      alert("Group created successfully!");
      router.push("/professor/courses");
    } catch (error) {
      console.error("Error creating group:", error);
      alert("Failed to create group. Please try again.");
    }
  };

  return (
    <div className="max-w-4xl mx-auto">
      <h1 className="text-3xl font-bold mb-6">Create a New Group</h1>
      <form onSubmit={handleSubmit} className="space-y-4">
        <div>
          <label
            htmlFor="nume"
            className="block text-sm font-medium text-gray-700"
          >
            Group Name
          </label>
          <input
            type="text"
            id="nume"
            value={nume}
            onChange={(e) => setNume(e.target.value)}
            className="mt-1 block w-full rounded-md border-gray-300 shadow-sm focus:border-indigo-300 focus:ring focus:ring-indigo-200 focus:ring-opacity-50"
            required
          />
        </div>
        <div>
          <label
            htmlFor="nivelStudiu"
            className="block text-sm font-medium text-gray-700"
          >
            Study Level
          </label>
          <input
            type="text"
            id="nivelStudiu"
            value={nivelStudiu}
            onChange={(e) => setNivelStudiu(e.target.value)}
            className="mt-1 block w-full rounded-md border-gray-300 shadow-sm focus:border-indigo-300 focus:ring focus:ring-indigo-200 focus:ring-opacity-50"
            required
          />
        </div>
        <div>
          <label
            htmlFor="linkMeet"
            className="block text-sm font-medium text-gray-700"
          >
            Meet Link
          </label>
          <input
            type="url"
            id="linkMeet"
            value={linkMeet}
            onChange={(e) => setLinkMeet(e.target.value)}
            className="mt-1 block w-full rounded-md border-gray-300 shadow-sm focus:border-indigo-300 focus:ring focus:ring-indigo-200 focus:ring-opacity-50"
            required
          />
        </div>
        <div>
          <label
            htmlFor="cursId"
            className="block text-sm font-medium text-gray-700"
          >
            Associated Course
          </label>
          <select
            id="cursId"
            value={cursId}
            onChange={(e) => setCursId(e.target.value)}
            className="mt-1 block w-full rounded-md border-gray-300 shadow-sm focus:border-indigo-300 focus:ring focus:ring-indigo-200 focus:ring-opacity-50"
            required
          >
            <option value="">Select a course</option>
            {courses.map((course) => (
              <option key={course.cursId} value={course.cursId}>
                {course.denumire}
              </option>
            ))}
          </select>
        </div>
        <button
          type="submit"
          className="inline-flex items-center px-4 py-2 border border-transparent rounded-md shadow-sm text-sm font-medium text-white bg-indigo-600 hover:bg-indigo-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500"
        >
          <Plus className="mr-2 -ml-1 h-5 w-5" aria-hidden="true" />
          Create Group
        </button>
      </form>
    </div>
  );
}
