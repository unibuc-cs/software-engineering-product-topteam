import type { Homework } from "../types/homework"

export const homeworkList: Homework[] = [
  {
    id: "1",
    title: "React Components Assignment",
    description:
      "Create a reusable React component that can display user information in card format. The should be flexible enough to handle different types of data.",
    courseId: "1",
    courseName: "Introduction to React",
    professorName: "Dr. Jane Smith",
    dueDate: "2023-07-15",
    submissionStatus: "not_submitted",
    attachments: [
      { name: "Assignment Details", url: "/files/react-components-assignment.pdf" },
      { name: "Example Code", url: "/files/example-user-card.js" },
    ],
  },
  {
    id: "2",
    title: "Data Visualization Project",
    description:
      "Using a dataset of your choice, create series data visualizations that tell compelling story. Use at least three different types charts or graphs.",
    courseId: "3",
    courseName: "Data Science Fundamentals",
    professorName: "Prof. Alex Johnson",
    dueDate: "2026-07-20",
    submissionStatus: "pending",
    attachments: [{ name: "Project Guidelines", url: "/files/data-viz-project.pdf" }],
  },
  {
    id: "3",
    title: "JavaScript Algorithms Challenge",
    description:
      "Implement three common sorting algorithms in JavaScript: Bubble Sort, Merge and Quick Sort. Compare their performance with different input sizes.",
    courseId: "2",
    courseName: "Advanced JavaScript Techniques",
    professorName: "Dr. Michael Lee",
    dueDate: "2023-07-10",
    submissionStatus: "reviewed",
    score: 92,
    attachments: [
      { name: "Algorithm Descriptions", url: "/files/sorting-algorithms.pdf" },
      { name: "Test Data", url: "/files/test-data.json" },
    ],
  },
]

