"use client"

import { useState } from "react"
import Link from "next/link"
import { courses } from "../data/courses"
import type { Course } from "../types/course"
import { currentUser } from "../data/user"
import { useRouter } from "next/navigation"

export default function ShopPage() {
  const [searchTerm, setSearchTerm] = useState("")
  const [selectedCategory, setSelectedCategory] = useState("")
  const [enrollingCourse, setEnrollingCourse] = useState<Course | null>(null)
  const [enrollmentDuration, setEnrollmentDuration] = useState(1)
  const router = useRouter()

  const categories = Array.from(new Set(courses.map((course) => course.category)))

  const filteredCourses = courses.filter(
    (course) =>
      course.name.toLowerCase().includes(searchTerm.toLowerCase()) &&
      (selectedCategory === "" || course.category === selectedCategory),
  )

  const handleEnroll = (course: Course) => {
    setEnrollingCourse(course)
  }

  const confirmEnrollment = () => {
    if (enrollingCourse) {
      // Here you would typically send this data to your backend
      console.log(`Enrolling in ${enrollingCourse.name} for ${enrollmentDuration} months`)
      // For now, we'll just simulate enrollment and redirect
      router.push(`/payment?course=${enrollingCourse.id}&duration=${enrollmentDuration}`)
    }
  }

  return (
    <div className="max-w-6xl mx-auto">
      <h1 className="text-3xl font-bold mb-6">Course Shop</h1>

      <div className="mb-6 flex space-x-4">
        <input
          type="text"
          placeholder="Search courses..."
          className="flex-grow p-2 border border-slate-200 rounded dark:border-slate-800"
          value={searchTerm}
          onChange={(e) => setSearchTerm(e.target.value)}
        />
        <select
          className="p-2 border border-slate-200 rounded dark:border-slate-800"
          value={selectedCategory}
          onChange={(e) => setSelectedCategory(e.target.value)}
        >
          <option value="">All Categories</option>
          {categories.map((category) => (
            <option key={category} value={category}>
              {category}
            </option>
          ))}
        </select>
      </div>

      <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
        {filteredCourses.map((course) => (
          <div key={course.id} className="border rounded-lg p-4 hover:shadow-lg transition duration-300">
            <h2 className="text-xl font-semibold mb-2">{course.name}</h2>
            <p className="text-gray-600 mb-2">{course.category}</p>
            <p className="text-blue-600 font-bold">${course.price.toFixed(2)} / month</p>
            {currentUser.enrolledCourses.includes(course.id) ? (
              <p className="mt-4 text-green-600">You are already enrolled</p>
            ) : (
              <button
                onClick={() => handleEnroll(course)}
                className="mt-4 bg-blue-500 text-white px-4 py-2 rounded hover:bg-blue-600 transition duration-300"
              >
                Enroll in Course
              </button>
            )}
          </div>
        ))}
      </div>

      {enrollingCourse && (
        <div className="fixed inset-0 bg-gray-600 bg-opacity-50 overflow-y-auto h-full w-full" id="my-modal">
          <div className="relative top-20 mx-auto p-5 border border-slate-200 w-96 shadow-lg rounded-md bg-white dark:border-slate-800">
            <div className="mt-3 text-center">
              <h3 className="text-lg leading-6 font-medium text-gray-900">Enroll in {enrollingCourse.name}</h3>
              <div className="mt-2 px-7 py-3">
                <p className="text-sm text-gray-500">For how many months do you want to subscribe?</p>
                <input
                  type="number"
                  value={enrollmentDuration}
                  onChange={(e) => setEnrollmentDuration(Math.max(1, Number.parseInt(e.target.value)))}
                  className="mt-3 p-2 border border-slate-200 rounded w-full dark:border-slate-800"
                  min="1"
                />
              </div>
              <div className="items-center px-4 py-3">
                <button
                  onClick={confirmEnrollment}
                  className="px-4 py-2 bg-blue-500 text-white text-base font-medium rounded-md w-full shadow-sm hover:bg-blue-600 focus:outline-none focus:ring-2 focus:ring-blue-300"
                >
                  Confirm Enrollment
                </button>
                <button
                  onClick={() => setEnrollingCourse(null)}
                  className="mt-3 px-4 py-2 bg-gray-100 text-gray-700 text-base font-medium rounded-md w-full shadow-sm hover:bg-gray-200 focus:outline-none focus:ring-2 focus:ring-gray-300"
                >
                  Cancel
                </button>
              </div>
            </div>
          </div>
        </div>
      )}
    </div>
  )
}

