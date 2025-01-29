"use client"

import { useState, useEffect } from "react"
import { X } from "lucide-react"

interface NotificationProps {
  message: string
  type: "success" | "error" | "info"
  duration?: number
}

export function Notification({ message, type, duration = 3000 }: NotificationProps) {
  const [isVisible, setIsVisible] = useState(true)

  useEffect(() => {
    const timer = setTimeout(() => {
      setIsVisible(false)
    }, duration)

    return () => clearTimeout(timer)
  }, [duration])

  if (!isVisible) return null

  const bgColor = type === "success" ? "bg-green-500" : type === "error" ? "bg-red-500" : "bg-blue-500"

  return (
    <div className={`fixed top-4 right-4 ${bgColor} text-white px-4 py-2 rounded-md shadow-md flex items-center`}>
      <span>{message}</span>
      <button onClick={() => setIsVisible(false)} className="ml-2">
        <X size={18} />
      </button>
    </div>
  )
}

