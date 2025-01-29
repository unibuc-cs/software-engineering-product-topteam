export interface ProfessorMeeting {
  id: string
  title: string
  startingDay: string
  startingHour: string
  endingHour: string
  class: string
}

export interface Course {
  id: string
  name: string
  description: string
  price: number
  category: string
  professorMeetings: number
  imageUrl: string
  professorId: string
  enrolledStudents: number
  meetings: ProfessorMeeting[]
  classReference?: string
}

