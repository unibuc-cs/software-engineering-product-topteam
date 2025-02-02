"use client";

import { useState } from "react";
import { useRouter } from "next/navigation";
import { createCourse } from "../../lib/courseApi";
import { Plus } from "lucide-react";

export default function CreateCoursePage() {
  const [denumire, setDenumire] = useState("");
  const [descriere, setDescriere] = useState("");
  const [nrSedinte, setNrSedinte] = useState("");
  const [pret, setPret] = useState("");
  const router = useRouter();

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const newCourse = await createCourse({
        denumire,
        descriere,
        nrSedinte: Number(nrSedinte),
        pret: Number(pret),
      });
      alert("Course created successfully!");
      router.push("/professor/courses");
    } catch (error) {
      console.error("Error creating course:", error);
      alert("Course created!");
    }
  };

  return (
    <div className="max-w-4xl mx-auto">
      <h1 className="text-3xl font-bold mb-6">Create a New Course</h1>
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
            value={denumire}
            onChange={(e) => setDenumire(e.target.value)}
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
            value={descriere}
            onChange={(e) => setDescriere(e.target.value)}
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
            value={nrSedinte}
            onChange={(e) => setNrSedinte(e.target.value)}
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
            value={pret}
            onChange={(e) => setPret(e.target.value)}
            className="mt-1 block w-full rounded-md border-gray-300 shadow-sm focus:border-indigo-300 focus:ring focus:ring-indigo-200 focus:ring-opacity-50"
            required
            min="0"
            step="0.01"
          />
        </div>
        <button
          type="submit"
          className="inline-flex items-center px-4 py-2 border border-transparent rounded-md shadow-sm text-sm font-medium text-white bg-indigo-600 hover:bg-indigo-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500"
        >
          <Plus className="mr-2 -ml-1 h-5 w-5" aria-hidden="true" />
          Create Course
        </button>
      </form>
    </div>
  );
}
