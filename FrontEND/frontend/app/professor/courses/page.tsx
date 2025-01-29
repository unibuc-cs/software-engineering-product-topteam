"use client"

import { useState } from "react"
import Link from "next/link"
import { courses } from "../../data/courses"
import { currentProfessor } from "../../data/professor"
import { EditCourse } from "../../components/EditCourse"
import type { Course } from "../../types/course"

export default function ProfessorCoursesPage() {
  const [editingCourseId, setEditingCourseId] = useState<string | null>(null)
  const [professorCourses, setProfessorCourses] = useState<Course[]>(
    courses.filter((course) => course.professorId === currentProfessor.id),
  )

  const handleEditCourse = (courseId: string) => {
    setEditingCourseId(courseId)
  }

  const handleSaveCourse = (updatedCourse: Course) => {
    setProfessorCourses((prevCourses) =>
      prevCourses.map((course) => (course.id === updatedCourse.id ? updatedCourse : course)),
    )
    setEditingCourseId(null)
  }

  const handleCancelEdit = () => {
    setEditingCourseId(null)
  }

  return (
    <div className="max-w-6xl mx-auto">
      <h1 className="text-3xl font-bold mb-6">Your Created Courses</h1>
      <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
        {professorCourses.map((course) => (
          <div key={course.id} className="border rounded-lg p-4 hover:shadow-lg transition duration-300">
            {editingCourseId === course.id ? (
              <EditCourse course={course} onSave={handleSaveCourse} onCancel={handleCancelEdit} />
            ) : (
              <>
                <h2 className="text-xl font-semibold mb-2">{course.name}</h2>
                <p className="text-gray-600 mb-2">{course.category}</p>
                <p className="text-blue-600 font-bold">${course.price.toFixed(2)}</p>
                <p className="text-sm text-gray-500 mt-2">Enrolled Students: {course.enrolledStudents}</p>
                <div className="mt-4 flex justify-between">
                  <Link
                    href={`/professor/courses/${course.id}`}
                    className="text-indigo-600 hover:text-indigo-800 font-medium"
                  >
                    View Details
                  </Link>
                  <button
                    onClick={() => handleEditCourse(course.id)}
                    className="text-green-600 hover:text-green-800 font-medium"
                  >
                    Edit Course
                  </button>
                </div>
              </>
            )}
          </div>
        ))}
      </div>
    </div>
  )
}

