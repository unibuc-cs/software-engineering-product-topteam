import type { Homework } from "../types/homework"

export function getHomeworkStatus(homework: Homework): string {
  const currentDate = new Date()
  const dueDate = new Date(homework.dueDate)

  if (homework.submissionStatus === "reviewed") {
    return "Reviewed"
  } else if (homework.submissionStatus === "submitted") {
    return "Pending Professor Review"
  } else if (currentDate > dueDate) {
    return "Overdue"
  } else {
    return "Pending"
  }
}

export function getStatusColor(status: string): string {
  switch (status) {
    case "Reviewed":
      return "bg-green-100 text-green-800"
    case "Pending Professor Review":
      return "bg-blue-100 text-blue-800"
    case "Overdue":
      return "bg-red-100 text-red-800"
    default:
      return "bg-yellow-100 text-yellow-800"
  }
}

export function getTimeRemaining(dueDate: string): string {
  const now = new Date()
  const due = new Date(dueDate)
  const timeRemaining = due.getTime() - now.getTime()

  if (timeRemaining <= 0) {
    return "Past due"
  }

  const days = Math.floor(timeRemaining / (1000 * 60 * 60 * 24))
  const hours = Math.floor((timeRemaining % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60))

  if (days > 0) {
    return `${days} day${days > 1 ? "s" : ""} remaining`
  } else {
    return `${hours} hour${hours > 1 ? "s" : ""} remaining`
  }
}

