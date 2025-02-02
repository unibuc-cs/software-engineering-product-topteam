"use client"

import { useState } from "react"
import type { ProfessorMeeting } from "../types/course"

interface ProfessorMeetingsProps {
  meetings: ProfessorMeeting[]
  onAddMeeting: (meeting: ProfessorMeeting) => void
  onDeleteMeeting: (meetingId: string) => void
}

export function ProfessorMeetings({ meetings, onAddMeeting, onDeleteMeeting }: ProfessorMeetingsProps) {
  const [newMeeting, setNewMeeting] = useState<Omit<ProfessorMeeting, "id">>({
    title: "",
    startingDay: "",
    startingHour: "",
    endingHour: "",
    class: "",
  })

  const handleInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target
    setNewMeeting((prev) => ({ ...prev, [name]: value }))
  }

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault()
    onAddMeeting({ ...newMeeting, id: Date.now().toString() })
    setNewMeeting({
      title: "",
      startingDay: "",
      startingHour: "",
      endingHour: "",
      class: "",
    })
  }

  return (
    <div className="mt-8">
      <h2 className="text-2xl font-bold mb-4">Professor Meetings</h2>
      <form onSubmit={handleSubmit} className="mb-6 space-y-4">
        <div>
          <label htmlFor="title" className="block text-sm font-medium text-gray-700">
            Title
          </label>
          <input
            type="text"
            id="title"
            name="title"
            value={newMeeting.title}
            onChange={handleInputChange}
            required
            className="mt-1 block w-full rounded-md border-gray-300 shadow-sm focus:border-indigo-300 focus:ring focus:ring-indigo-200 focus:ring-opacity-50"
          />
        </div>
        <div>
          <label htmlFor="startingDay" className="block text-sm font-medium text-gray-700">
            Starting Day
          </label>
          <input
            type="date"
            id="startingDay"
            name="startingDay"
            value={newMeeting.startingDay}
            onChange={handleInputChange}
            required
            className="mt-1 block w-full rounded-md border-gray-300 shadow-sm focus:border-indigo-300 focus:ring focus:ring-indigo-200 focus:ring-opacity-50"
          />
        </div>
        <div>
          <label htmlFor="startingHour" className="block text-sm font-medium text-gray-700">
            Starting Hour
          </label>
          <input
            type="time"
            id="startingHour"
            name="startingHour"
            value={newMeeting.startingHour}
            onChange={handleInputChange}
            required
            className="mt-1 block w-full rounded-md border-gray-300 shadow-sm focus:border-indigo-300 focus:ring focus:ring-indigo-200 focus:ring-opacity-50"
          />
        </div>
        <div>
          <label htmlFor="endingHour" className="block text-sm font-medium text-gray-700">
            Ending Hour
          </label>
          <input
            type="time"
            id="endingHour"
            name="endingHour"
            value={newMeeting.endingHour}
            onChange={handleInputChange}
            required
            className="mt-1 block w-full rounded-md border-gray-300 shadow-sm focus:border-indigo-300 focus:ring focus:ring-indigo-200 focus:ring-opacity-50"
          />
        </div>
        <div>
          <label htmlFor="class" className="block text-sm font-medium text-gray-700">
            Class
          </label>
          <input
            type="text"
            id="class"
            name="class"
            value={newMeeting.class}
            onChange={handleInputChange}
            required
            className="mt-1 block w-full rounded-md border-gray-300 shadow-sm focus:border-indigo-300 focus:ring focus:ring-indigo-200 focus:ring-opacity-50"
          />
        </div>
        <button
          type="submit"
          className="px-4 py-2 border border-slate-200 border-transparent rounded-md shadow-sm text-sm font-medium text-white bg-indigo-600 hover:bg-indigo-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500 dark:border-slate-800"
        >
          Add Meeting
        </button>
      </form>
      <div className="space-y-4">
        {meetings.map((meeting) => (
          <div key={meeting.id} className="border rounded-lg p-4">
            <h3 className="text-lg font-semibold">{meeting.title}</h3>
            <p className="text-sm text-gray-600">
              Date: {meeting.startingDay} | Time: {meeting.startingHour} - {meeting.endingHour}
            </p>
            <p className="text-sm text-gray-600">Class: {meeting.class}</p>
            <button
              onClick={() => onDeleteMeeting(meeting.id)}
              className="mt-2 text-red-600 hover:text-red-800 text-sm font-medium"
            >
              Delete Meeting
            </button>
          </div>
        ))}
      </div>
    </div>
  )
}

