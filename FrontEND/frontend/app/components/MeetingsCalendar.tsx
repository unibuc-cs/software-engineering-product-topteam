import type { ProfessorMeeting } from "../types/course"

interface MeetingsCalendarProps {
  meetings: ProfessorMeeting[]
}

export function MeetingsCalendar({ meetings }: MeetingsCalendarProps) {
  const sortedMeetings = [...meetings].sort(
    (a, b) => new Date(a.startingDay).getTime() - new Date(b.startingDay).getTime(),
  )

  return (
    <div className="bg-white shadow overflow-hidden sm:rounded-md">
      <ul role="list" className="divide-y divide-gray-200">
        {sortedMeetings.map((meeting) => {
          const meetingDate = new Date(meeting.startingDay)
          const isPast = meetingDate < new Date()

          return (
            <li key={meeting.id}>
              <div className="px-4 py-4 sm:px-6">
                <div className="flex items-center justify-between">
                  <p className="text-sm font-medium text-indigo-600 truncate">{meeting.title}</p>
                  <div className="ml-2 flex-shrink-0 flex">
                    <p
                      className={`px-2 inline-flex text-xs leading-5 font-semibold rounded-full ${
                        isPast ? "bg-gray-100 text-gray-800" : "bg-green-100 text-green-800"
                      }`}
                    >
                      {isPast ? "Past" : "Upcoming"}
                    </p>
                  </div>
                </div>
                <div className="mt-2 sm:flex sm:justify-between">
                  <div className="sm:flex">
                    <p className="flex items-center text-sm text-gray-500">
                      <svg
                        className="flex-shrink-0 mr-1.5 h-5 w-5 text-gray-400"
                        xmlns="http://www.w3.org/2000/svg"
                        viewBox="0 20"
                        fill="currentColor"
                      >
                        <path
                          fillRule="evenodd"
                          d="M6 2a1 1 0 00-1 1v1H4a2 2 00-2 2v10a2 002 2h12a2 002-2V6a2 00-2-2h-1V3a1 10-2 0v1H7V3a1 00-1-1zm0 5a1 000 2h8a1 100-2H6z"
                          clipRule="evenodd"
                        />
                      </svg>
                      {meeting.startingDay}
                    </p>
                    <p className="mt-2 flex items-center text-sm text-gray-500 sm:mt-0 sm:ml-6">
                      <svg
                        className="flex-shrink-0 mr-1.5 h-5 w-5 text-gray-400"
                        xmlns="http://www.w3.org/2000/svg"
                        viewBox="0 20"
                        fill="currentColor"
                      >
                        <path
                          fillRule="evenodd"
                          d="M10 18a8 8 0 100-16 000 16zm1-12a1 1 10-2 0v4a1 00.293.707l2.828 2.829a1 101.415-1.415L11 9.586V6z"
                          clipRule="evenodd"
                        />
                      </svg>
                      {meeting.startingHour} - {meeting.endingHour}
                    </p>
                  </div>
                  <div className="mt-2 flex items-center text-sm text-gray-500 sm:mt-0">
                    <svg
                      className="flex-shrink-0 mr-1.5 h-5 w-5 text-gray-400"
                      xmlns="http://www.w3.org/2000/svg"
                      viewBox="0 20"
                      fill="currentColor"
                    >
                      <path d="M9 6a3 3 0 11-6 016 0zM17 0zM12.93 17c.046-.327.07-.66.07-1a6.97 6.97 00-1.5-4.33A5 5 0119 16v1h-6.07zM6 11a5 015 5v1H1v-1a5 015-5z" />
                    </svg>
                    Class: {meeting.class}
                  </div>
                </div>
              </div>
            </li>
          )
        })}
      </ul>
    </div>
  )
}

