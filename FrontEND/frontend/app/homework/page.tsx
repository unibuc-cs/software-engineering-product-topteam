"use client"

import Link from "next/link"
import { homeworkList } from "../data/homework"
import { getHomeworkStatus, getStatusColor, getTimeRemaining } from "../utils/homeworkUtils"

export default function HomeworkOverviewPage() {
  const groupedHomework = homeworkList.reduce(
    (acc, homework) => {
      if (!acc[homework.courseId]) {
        acc[homework.courseId] = []
      }
      acc[homework.courseId].push(homework)
      return acc
    },
    {} as Record<string, typeof homeworkList>,
  )

  return (
    <div className="max-w-6xl mx-auto">
      <h1 className="text-3xl font-bold mb-8">Homework Overview</h1>
      {Object.entries(groupedHomework).map(([courseId, homeworks]) => (
        <div key={courseId} className="mb-8">
          <h2 className="text-2xl font-semibold mb-4">{homeworks[0].courseName}</h2>
          <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
            {homeworks.map((homework) => {
              const status = getHomeworkStatus(homework)
              const statusColor = getStatusColor(status)
              const timeRemaining = getTimeRemaining(homework.dueDate)

              return (
                <Link href={`/homework/${homework.id}`} key={homework.id} className="block">
                  <div className="bg-white rounded-lg overflow-hidden shadow-lg hover:shadow-xl transition duration-300">
                    <div className="p-6">
                      <h3 className="text-xl font-semibold mb-2 text-gray-800">{homework.title}</h3>
                      <p className="text-gray-600 mb-4 line-clamp-2">{homework.description}</p>
                      <div className="flex justify-between items-center mb-2">
                        <span className="text-sm text-gray-500">Due: {homework.dueDate}</span>
                        <span className={`text-sm font-semibold px-2 py-1 rounded-full ${statusColor}`}>{status}</span>
                      </div>
                      {status === "Pending" && <div className="text-sm text-gray-500">{timeRemaining}</div>}
                      {status === "Reviewed" && (
                        <div className="text-sm font-semibold text-green-600">Score: {homework.score}%</div>
                      )}
                    </div>
                  </div>
                </Link>
              )
            })}
          </div>
        </div>
      ))}
    </div>
  )
}

