"use client";

import { useState, useEffect } from "react";
import { useRouter } from "next/navigation";
import { getCourse } from "../../../lib/courseApi";
import type { Course } from "../../../types/course";
import type { Group } from "../../../types/group";

export default function EnrollPage({ params }: { params: { id: string } }) {
  const [course, setCourse] = useState<Course | null>(null);
  const [groups, setGroups] = useState<Group[]>([]);
  const [selectedGroupId, setSelectedGroupId] = useState<number | null>(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);
  const router = useRouter();
  const API_BASE_URL = "http://localhost:5081/api";

  useEffect(() => {
    async function fetchData() {
      try {
        const fetchedCourse = await getCourse(Number.parseInt(params.id));
        setCourse(fetchedCourse);
        const response = await fetch(`${API_BASE_URL}/Grupa`);
        if (!response.ok) {
          throw new Error("Failed to fetch groups");
        }
        const allGroups: Group[] = await response.json();
        const courseGroups = allGroups.filter(
          (group) => group.cursId === fetchedCourse.cursId
        );
        setGroups(courseGroups);
        if (typeof window !== "undefined") {
          localStorage.setItem("courseGroups", JSON.stringify(courseGroups));
        }
        setLoading(false);
      } catch (err) {
        setError("Failed to load data. Please try again later.");
        setLoading(false);
      }
    }

    fetchData();
  }, [params.id]);

  const handleGroupSelect = (groupId: number) => {
    setSelectedGroupId(groupId);
    // Store the selected group in localStorage
    const selectedGroup = groups.find((group) => group.id === groupId);
    if (selectedGroup) {
      localStorage.setItem("selectedGroup", JSON.stringify(selectedGroup));
    }
  };

  const handleContinue = () => {
    if (selectedGroupId !== null) {
      const selectedGroup = groups.find(
        (group) => group.id === selectedGroupId
      );
      if (selectedGroup && typeof window !== "undefined") {
        try {
          localStorage.setItem("selectedGroup", JSON.stringify(selectedGroup));
          console.log("Group stored in localStorage:", selectedGroup);
        } catch (err) {
          console.error("Failed to store group in localStorage:", err);
        }
      }
      router.push(`/courses/${params.id}/enroll/payment`);
    }
  };

  if (loading) return <div>Loading...</div>;
  if (error) return <div className="text-red-500">{error}</div>;
  if (!course) return <div>Course not found</div>;

  return (
    <div className="max-w-4xl mx-auto">
      <h1 className="text-3xl font-bold mb-6">Enroll in {course.denumire}</h1>
      <h2 className="text-xl font-semibold mb-4">Select a Group</h2>
      <div className="space-y-4">
        {groups.map((group) => (
          <div
            key={group.id}
            className={`p-4 border rounded-lg cursor-pointer ${
              selectedGroupId === group.id
                ? "border-indigo-500 bg-indigo-50"
                : "border-gray-200"
            }`}
            onClick={() => handleGroupSelect(group.id ?? 0)}
          >
            <h3 className="font-medium">{group.nume}</h3>
            <p className="text-sm text-gray-500">
              Study Level: {group.nivelStudiu}
            </p>
          </div>
        ))}
      </div>
      <div className="mt-6">
        <button
          onClick={handleContinue}
          disabled={selectedGroupId === null}
          className={`px-4 py-2 border border-transparent text-sm font-medium rounded-md shadow-sm text-white ${
            selectedGroupId !== null
              ? "bg-indigo-600 hover:bg-indigo-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500"
              : "bg-gray-300 cursor-not-allowed"
          }`}
        >
          Continue to Payment
        </button>
      </div>
    </div>
  );
}
