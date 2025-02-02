"use client";

import { useState, useEffect } from "react";
import { useRouter } from "next/navigation";
import { getAllGroups, assignHomework } from "../../lib/professorApi";
import type { Group } from "../../types/group";
// import type { User } from "../../types/user" // Removed import

export default function AssignHomeworkPage() {
  const [allGroups, setAllGroups] = useState<Group[]>([]);
  const [professorGroups, setProfessorGroups] = useState<Group[]>([]);
  // const [allUsers, setAllUsers] = useState<User[]>([]) // Removed state
  const [selectedGroup, setSelectedGroup] = useState<string>("");
  const [title, setTitle] = useState("");
  const [description, setDescription] = useState("");
  const [loading, setLoading] = useState(true);
  const [assigning, setAssigning] = useState(false);
  const [error, setError] = useState<string | null>(null);
  const router = useRouter();

  useEffect(() => {
    async function fetchData() {
      try {
        const groups = await getAllGroups();
        setAllGroups(groups);

        const professorId = localStorage.getItem("userId");
        if (!professorId) {
          throw new Error("Professor ID not found");
        }

        const filteredGroups = groups.filter(
          (group) => group.userProfesorId === Number(professorId)
        );
        setProfessorGroups(filteredGroups);

        setLoading(false);
      } catch (err) {
        console.error("Error fetching data:", err);
        setError("Failed to load data. Please try again later.");
        setLoading(false);
      }
    }

    fetchData();
  }, []);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    if (!selectedGroup) {
      setError("Please select a group");
      return;
    }

    setAssigning(true);
    setError(null);

    try {
      // Hardcode the user ID to 15
      const userId = 15;

      await assignHomework(userId, title, description);

      alert("Homework assigned successfully to user with ID 15!");
      router.push("/professor/courses");
    } catch (err) {
      console.error("Error assigning homework:", err);
      setError("Failed to assign homework. Please try again.");
    } finally {
      setAssigning(false);
    }
  };

  if (loading) {
    return <div className="max-w-4xl mx-auto p-6">Loading data...</div>;
  }

  return (
    <div className="max-w-4xl mx-auto p-6">
      <h1 className="text-3xl font-bold mb-6">Assign Homework</h1>
      {error && <div className="text-red-500 mb-4">{error}</div>}
      <form onSubmit={handleSubmit} className="space-y-4">
        <div>
          <label
            htmlFor="group"
            className="block text-sm font-medium text-gray-700"
          >
            Choose Group
          </label>
          <select
            id="group"
            value={selectedGroup}
            onChange={(e) => setSelectedGroup(e.target.value)}
            className="mt-1 block w-full pl-3 pr-10 py-2 text-base border-gray-300 focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 sm:text-sm rounded-md"
            required
          >
            <option value="">Select a group</option>
            {professorGroups.map((group) => (
              <option key={group.id} value={group.id}>
                {group.nume}
              </option>
            ))}
          </select>
        </div>
        <div>
          <label
            htmlFor="title"
            className="block text-sm font-medium text-gray-700"
          >
            Homework Title
          </label>
          <input
            type="text"
            id="title"
            value={title}
            onChange={(e) => setTitle(e.target.value)}
            className="mt-1 block w-full border border-gray-300 rounded-md shadow-sm py-2 px-3 focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 sm:text-sm"
            required
          />
        </div>
        <div>
          <label
            htmlFor="description"
            className="block text-sm font-medium text-gray-700"
          >
            Description
          </label>
          <textarea
            id="description"
            value={description}
            onChange={(e) => setDescription(e.target.value)}
            rows={4}
            className="mt-1 block w-full border border-gray-300 rounded-md shadow-sm py-2 px-3 focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 sm:text-sm"
            required
          ></textarea>
        </div>
        <div>
          <button
            type="submit"
            disabled={assigning}
            className={`inline-flex items-center px-4 py-2 border border-transparent text-sm font-medium rounded-md shadow-sm text-white bg-indigo-600 hover:bg-indigo-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500 ${
              assigning ? "opacity-50 cursor-not-allowed" : ""
            }`}
          >
            {assigning ? "Assigning..." : "Assign Homework"}
          </button>
        </div>
      </form>
    </div>
  );
}
