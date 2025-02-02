"use client"

import { useParams } from "next/navigation"
import { useState, useCallback } from "react"
import { useDropzone } from "react-dropzone"
import { homeworkList } from "../../data/homework"
import { getHomeworkStatus, getStatusColor, getTimeRemaining } from "../../utils/homeworkUtils"
import { FileText, Upload } from "lucide-react"

export default function HomeworkDetailsPage() {
  const { id } = useParams()
  const homework = homeworkList.find((h) => h.id === id)
  const [uploadedFiles, setUploadedFiles] = useState<File[]>([])
  const [isSubmitting, setIsSubmitting] = useState(false)
  const [submitMessage, setSubmitMessage] = useState("")

  const onDrop = useCallback((acceptedFiles: File[]) => {
    setUploadedFiles((prevFiles) => [...prevFiles, ...acceptedFiles])
  }, [])

  const { getRootProps, getInputProps, isDragActive } = useDropzone({ onDrop })

  const handleSubmit = () => {
    setIsSubmitting(true)
    // Simulating an API call
    setTimeout(() => {
      setIsSubmitting(false)
      setSubmitMessage("Your homework has been submitted successfully!")
      setUploadedFiles([])
    }, 2000)
  }

  if (!homework) {
    return <div>Homework not found</div>
  }

  const status = getHomeworkStatus(homework)
  const statusColor = getStatusColor(status)
  const timeRemaining = getTimeRemaining(homework.dueDate)

  return (
    <div className="max-w-4xl mx-auto">
      <h1 className="text-3xl font-bold mb-4">{homework.title}</h1>
      <div className="bg-white shadow-lg rounded-lg overflow-hidden mb-6">
        <div className="p-6">
          <p className="text-gray-600 mb-4">{homework.description}</p>
          <div className="mb-4">
            <strong className="text-gray-700">Course:</strong> {homework.courseName}
          </div>
          <div className="mb-4">
            <strong className="text-gray-700">Professor:</strong> {homework.professorName}
          </div>
          <div className="mb-4">
            <strong className="text-gray-700">Due Date:</strong> {homework.dueDate}
          </div>
          <div className="mb-4">
            <strong className="text-gray-700">Status:</strong>
            <span className={`ml-2 px-2 py-1 rounded-full text-sm font-semibold ${statusColor}`}>{status}</span>
          </div>
          {status === "Pending" && (
            <div className="mb-4">
              <strong className="text-gray-700">Time Remaining:</strong> {timeRemaining}
            </div>
          )}
          {status === "Reviewed" && (
            <div className="mb-4">
              <strong className="text-gray-700">Score:</strong> {homework.score}%
            </div>
          )}
          <div>
            <strong className="text-gray-700">Attachments:</strong>
            <ul className="mt-2 space-y-2">
              {homework.attachments.map((attachment, index) => (
                <li key={index}>
                  <a
                    href={attachment.url}
                    className="flex items-center text-blue-600 hover:text-blue-800"
                    target="_blank"
                    rel="noopener noreferrer"
                  >
                    <FileText className="w-4 h-4 mr-2" />
                    {attachment.name}
                  </a>
                </li>
              ))}
            </ul>
          </div>
        </div>
      </div>

      {status === "Pending" && (
        <div className="bg-white shadow-lg rounded-lg overflow-hidden mb-6">
          <div className="p-6">
            <h2 className="text-2xl font-semibold mb-4">Submit Your Homework</h2>
            <div
              {...getRootProps()}
              className={`border-2 border-dashed rounded-lg p-6 mb-4 ${isDragActive ? "border-blue-500 bg-blue-50" : "border-gray-300"}`}
            >
              <input {...getInputProps()} />
              <div className="text-center">
                <Upload className="mx-auto h-12 w-12 text-gray-400" />
                <p className="mt-1">Drag and drop your files here, or click to select files</p>
              </div>
            </div>
            {uploadedFiles.length > 0 && (
              <div className="mb-4">
                <h3 className="font-semibold mb-2">Uploaded Files:</h3>
                <ul className="list-disc pl-5">
                  {uploadedFiles.map((file, index) => (
                    <li key={index}>{file.name}</li>
                  ))}
                </ul>
              </div>
            )}
            <button
              onClick={handleSubmit}
              disabled={isSubmitting || uploadedFiles.length === 0}
              className={`w-full bg-blue-500 text-white py-2 px-4 rounded-lg ${isSubmitting || uploadedFiles.length === 0 ? "opacity-50 cursor-not-allowed" : "hover:bg-blue-600"}`}
            >
              {isSubmitting ? "Submitting..." : "Submit Homework"}
            </button>
            {submitMessage && <div className="mt-4 p-3 bg-green-100 text-green-700 rounded-lg">{submitMessage}</div>}
          </div>
        </div>
      )}
    </div>
  )
}

