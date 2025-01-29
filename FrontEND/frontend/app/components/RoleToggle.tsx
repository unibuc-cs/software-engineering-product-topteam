"use client"

import { useState, useEffect } from "react"
import { useRouter } from "next/navigation"

export function RoleToggle() {
  const [role, setRole] = useState("student")
  const router = useRouter()

  useEffect(() => {
    const storedRole = localStorage.getItem("userRole")
    if (storedRole) {
      setRole(storedRole)
    }
  }, [])

  const handleRoleChange = (newRole: string) => {
    setRole(newRole)
    localStorage.setItem("userRole", newRole)
    router.push(newRole === "student" ? "/" : "/professor")
  }

  return (
    <div className="mb-4">
      <label className="mr-2">Role:</label>
      <select value={role} onChange={(e) => handleRoleChange(e.target.value)} className="border rounded p-1">
        <option value="student">Student</option>
        <option value="professor">Professor</option>
      </select>
    </div>
  )
}

