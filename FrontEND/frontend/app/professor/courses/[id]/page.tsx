"use client"

import { useState } from "react"
import { useParams } from "next/navigation"
import { courses } from "../../../data/courses"
import { EditCourse } from "../../../components/EditCourse"
import { ProfessorMeetings } from "../../../components/ProfessorMeetings"
import type { Course, ProfessorMeeting } from "../../../types/course"

export default function CourseDetailsPage() {
  const { id } = useParams()
  const [course, setCourse] = useState<Course | undefined>(courses.find((c) => c.id === id))
  const [isEditing, setIsEditing] = useState(false)

  if (!course) {
    return <div>Course not found</div>
  }

  const handleSaveCourse = (updatedCourse: Course) => {
    setCourse(updatedCourse)
    setIsEditing(false)
  }

  const handleAddMeeting = (newMeeting: ProfessorMeeting) => {
    setCourse((prevCourse) => {
      if (!prevCourse) return prevCourse
      return {
        ...prevCourse,
        meetings: [...prevCourse.meetings, newMeeting],
      }
    })
  }

  const handleDeleteMeeting = (meetingId: string) => {
    setCourse((prevCourse) => {
      if (!prevCourse) return prevCourse
      return {
        ...prevCourse,
        meetings: prevCourse.meetings.filter((meeting) => meeting.id !== meetingId),
      }
    })
  }

  return (
    <div className="max-w-4xl mx-auto">
      <h1 className="text-3xl font-bold mb-4">{course.name}</h1>
      {isEditing ? (
        <EditCourse course={course} onSave={handleSaveCourse} onCancel={() => setIsEditing(false)} />
      ) : (
        <div className="bg-white shadow-md rounded-lg p-6">
          <p className="text-gray-600 mb-4">{course.description}</p>
          <div className="flex justify-between items-center mb-4">
            <span className="text-blue-600 font-bold text-xl">${course.price.toFixed(2)}</span>
            <span className="text-gray-500">Category: {course.category}</span>
          </div>
          <p className="text-gray-600">Enrolled Students: {course.enrolledStudents}</p>
          <button
            onClick={() => setIsEditing(true)}
            className="mt-4 px-4 py-2 border border-slate-200 border-transparent rounded-md shadow-sm text-sm font-medium text-white bg-indigo-600 hover:bg-indigo-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500 dark:border-slate-800"
          >
            Edit Course
          </button>
        </div>
      )}
      <ProfessorMeetings
        meetings={course.meetings}
        onAddMeeting={handleAddMeeting}
        onDeleteMeeting={handleDeleteMeeting}
      />
    </div>
  )
}

