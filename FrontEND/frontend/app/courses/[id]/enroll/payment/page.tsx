"use client";

import { useState, useEffect } from "react";
import { useRouter } from "next/navigation";

interface Group {
  grupaId: number;
  nume: string;
  nivelStudiu: string;
}

export default function PaymentPage({ params }: { params: { id: string } }) {
  const [cardNumber, setCardNumber] = useState("");
  const [expiryDate, setExpiryDate] = useState("");
  const [cvv, setCvv] = useState("");
  const [name, setName] = useState("");
  const [selectedGroup, setSelectedGroup] = useState<Group | null>(null);
  const router = useRouter();
  const API_BASE_URL = "http://localhost:5081/api";

  useEffect(() => {
    const storedGroup = localStorage.getItem("selectedGroup");
    if (storedGroup) {
      setSelectedGroup(JSON.parse(storedGroup));
    }
  }, []);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    if (selectedGroup) {
      const userId = localStorage.getItem("userId");
      if (!userId) {
        alert("User ID not found. Please log in again.");
        return;
      }

      try {
        const response = await fetch(
          `${API_BASE_URL}/User/addGroups?userId=${userId}`,
          {
            method: "PUT",
            headers: {
              "Content-Type": "application/json",
            },
            body: JSON.stringify([selectedGroup.grupaId]),
          }
        );

        if (response.ok) {
          alert("Enrollment successful!");
          localStorage.removeItem("selectedGroup");
          router.push("/enrolled-courses");
        } else {
          const errorData = await response.json();
          alert(`Enrollment failed: ${errorData.message || "Unknown error"}`);
        }
      } catch (error) {
        console.error("Error enrolling user:", error);
        alert("An error occurred while enrolling. Please try again.");
      }
    } else {
      alert("No group selected. Please select a group before proceeding.");
    }
  };

  return (
    <div className="max-w-4xl mx-auto">
      {selectedGroup && (
        <div className="mb-6">
          <h2 className="text-xl font-semibold mb-2">Selected Group</h2>
          <p>
            <strong>Name:</strong> {selectedGroup.nume}
          </p>
          <p>
            <strong>Study Level:</strong> {selectedGroup.nivelStudiu}
          </p>
        </div>
      )}
      <h1 className="text-3xl font-bold mb-6">Payment Details</h1>
      <form onSubmit={handleSubmit} className="space-y-4">
        <div>
          <label
            htmlFor="name"
            className="block text-sm font-medium text-gray-700"
          >
            Cardholder Name
          </label>
          <input
            type="text"
            id="name"
            value={name}
            onChange={(e) => setName(e.target.value)}
            className="mt-1 block w-full border border-gray-300 rounded-md shadow-sm py-2 px-3 focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 sm:text-sm"
            required
          />
        </div>
        <div>
          <label
            htmlFor="cardNumber"
            className="block text-sm font-medium text-gray-700"
          >
            Card Number
          </label>
          <input
            type="text"
            id="cardNumber"
            value={cardNumber}
            onChange={(e) => setCardNumber(e.target.value)}
            className="mt-1 block w-full border border-gray-300 rounded-md shadow-sm py-2 px-3 focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 sm:text-sm"
            required
          />
        </div>
        <div className="flex space-x-4">
          <div className="flex-1">
            <label
              htmlFor="expiryDate"
              className="block text-sm font-medium text-gray-700"
            >
              Expiry Date
            </label>
            <input
              type="text"
              id="expiryDate"
              value={expiryDate}
              onChange={(e) => setExpiryDate(e.target.value)}
              placeholder="MM/YY"
              className="mt-1 block w-full border border-gray-300 rounded-md shadow-sm py-2 px-3 focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 sm:text-sm"
              required
            />
          </div>
          <div className="flex-1">
            <label
              htmlFor="cvv"
              className="block text-sm font-medium text-gray-700"
            >
              CVV
            </label>
            <input
              type="text"
              id="cvv"
              value={cvv}
              onChange={(e) => setCvv(e.target.value)}
              className="mt-1 block w-full border border-gray-300 rounded-md shadow-sm py-2 px-3 focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 sm:text-sm"
              required
            />
          </div>
        </div>
        <div>
          <button
            type="submit"
            className="w-full flex justify-center py-2 px-4 border border-transparent rounded-md shadow-sm text-sm font-medium text-white bg-indigo-600 hover:bg-indigo-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500"
          >
            Pay and Enroll
          </button>
        </div>
      </form>
    </div>
  );
}
