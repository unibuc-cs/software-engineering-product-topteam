"use client"

import { useEffect } from "react"
import { useRouter } from "next/navigation"
import { getUserRole } from "../utils/roleManager"

export default function ProfessorLayout({
  children,
}: {
  children: React.ReactNode
}) {
  const router = useRouter()

  useEffect(() => {
    if (getUserRole() !== "professor") {
      router.push("/")
    }
  }, [router])

  return <>{children}</>
}

