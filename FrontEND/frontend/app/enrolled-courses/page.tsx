"use client"

import Link from "next/link"
import Image from "next/image"
import { courses } from "../data/courses"
import { currentUser } from "../data/user"
import type { ProfessorMeeting } from "../types/course"

function getUpcomingMeetings(meetings: ProfessorMeeting[], limit = 2): ProfessorMeeting[] {
  const now = new Date()
  return meetings
    .filter((meeting) => new Date(meeting.startingDay) >= now)
    .sort((a, b) => new Date(a.startingDay).getTime() - new Date(b.startingDay).getTime())
    .slice(0, limit)
}

export default function EnrolledCoursesPage() {
  const enrolledCourses = courses.filter((course) => currentUser.enrolledCourses.includes(course.id))

  if (enrolledCourses.length === 0) {
    return (
      <div className="max-w-4xl mx-auto text-center">
        <h1 className="text-3xl font-bold mb-6">Enrolled Courses</h1>
        <p className="text-xl text-gray-600 mb-4">You haven't enrolled in any courses yet.</p>
        <Link
          href="/shop"
          className="inline-block bg-blue-500 text-white px-6 py-2 rounded hover:bg-blue-600 transition duration-300"
        >
          Browse Courses
        </Link>
      </div>
    )
  }

  return (
    <div className="max-w-6xl mx-auto">
      <h1 className="text-3xl font-bold mb-8">Enrolled Courses</h1>
      <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-8">
        {enrolledCourses.map((course) => (
          <div
            key={course.id}
            className="bg-white rounded-lg overflow-hidden shadow-lg hover:shadow-xl transition duration-300"
          >
            <Link href={`/courses/${course.id}`}>
              <Image
                src={course.imageUrl || "/placeholder.svg"}
                alt={course.name}
                width={300}
                height={200}
                className="w-full h-48 object-cover"
              />
              <div className="p-6">
                <h2 className="text-xl font-semibold mb-2 text-gray-800">{course.name}</h2>
                <p className="text-gray-600 mb-4 line-clamp-2">{course.description}</p>
                <div className="flex justify-between items-center mb-4">
                  <span className="text-sm text-gray-500">{course.category}</span>
                  <span className="text-sm font-semibold text-green-600">Enrolled</span>
                </div>
                {course.meetings.length > 0 && (
                  <div>
                    <h3 className="text-lg font-semibold mb-2">Upcoming Meetings</h3>
                    <ul className="space-y-2">
                      {getUpcomingMeetings(course.meetings).map((meeting) => (
                        <li key={meeting.id} className="text-sm">
                          <p className="font-medium">{meeting.title}</p>
                          <p className="text-gray-600">
                            {meeting.startingDay}, {meeting.startingHour} - {meeting.endingHour}
                          </p>
                        </li>
                      ))}
                    </ul>
                  </div>
                )}
              </div>
            </Link>
          </div>
        ))}
      </div>
    </div>
  )
}

