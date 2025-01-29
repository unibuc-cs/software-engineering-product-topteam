"use client"

import { useParams } from "next/navigation"
import { courses } from "../../data/courses"
import { currentUser } from "../../data/user"
import { MeetingsCalendar } from "../../components/MeetingsCalendar"

export default function CourseDetailsPage() {
  const { id } = useParams()
  const course = courses.find((c) => c.id === id)
  const isEnrolled = currentUser.enrolledCourses.includes(id as string)

  if (!course) {
    return <div>Course not found</div>
  }

  return (
    <div className="max-w-4xl mx-auto">
      <h1 className="text-3xl font-bold mb-4">{course.name}</h1>
      <div className="bg-white shadow-md rounded-lg p-6 mb-6">
        <p className="text-gray-600 mb-4">{course.description}</p>
        <div className="flex justify-between items-center mb-4">
          <span className="text-blue-600 font-bold text-xl">${course.price.toFixed(2)}</span>
          <span className="text-gray-500">Category: {course.category}</span>
        </div>
        <p className="text-gray-600">Number of meetings with professor: {course.professorMeetings}</p>
        {isEnrolled ? (
          <button className="mt-6 bg-green-500 text-white px-4 py-2 rounded hover:bg-green-600 transition duration-300">
            Go to Course
          </button>
        ) : (
          <button className="mt-6 bg-blue-500 text-white px-4 py-2 rounded hover:bg-blue-600 transition duration-300">
            Enroll in Course
          </button>
        )}
      </div>

      {isEnrolled && course.meetings.length > 0 && (
        <div className="mt-8">
          <h2 className="text-2xl font-bold mb-4">Professor Meetings</h2>
          <MeetingsCalendar meetings={course.meetings} />
        </div>
      )}
    </div>
  )
}

