let userRole: "student" | "professor" = "student"

export function setUserRole(role: "student" | "professor") {
  userRole = role
  localStorage.setItem("userRole", role)
}

export function getUserRole(): "student" | "professor" {
  const storedRole = localStorage.getItem("userRole")
  if (storedRole === "student" || storedRole === "professor") {
    userRole = storedRole
  }
  return userRole
}

// Initialize the role from localStorage
if (typeof window !== "undefined") {
  getUserRole()
}

