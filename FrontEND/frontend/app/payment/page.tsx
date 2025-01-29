"use client"

import { useSearchParams } from "next/navigation"

export default function PaymentPage() {
  const searchParams = useSearchParams()
  const courseId = searchParams.get("course")
  const duration = searchParams.get("duration")

  return (
    <div className="max-w-4xl mx-auto">
      <h1 className="text-3xl font-bold mb-6">Payment Confirmation</h1>
      <div className="bg-white shadow-md rounded-lg p-6">
        <p className="text-lg mb-4">
          You are about to enroll in course ID: <strong>{courseId}</strong>
        </p>
        <p className="text-lg mb-4">
          Subscription duration: <strong>{duration} month(s)</strong>
        </p>
        <p className="text-xl font-semibold mb-6">Total amount: $XX.XX</p>
        <button className="bg-blue-500 text-white px-6 py-2 rounded hover:bg-blue-600 transition duration-300">
          Proceed to Payment
        </button>
      </div>
    </div>
  )
}

