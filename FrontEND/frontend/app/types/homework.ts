export interface Homework {
  id: string
  title: string
  description: string
  courseId: string
  courseName: string
  professorName: string
  dueDate: string
  submissionStatus: "not_submitted" | "submitted" | "reviewed"
  score?: number
  attachments: Array<{
    name: string
    url: string
  }>
}

