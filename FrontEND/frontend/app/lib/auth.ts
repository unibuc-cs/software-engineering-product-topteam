import type { LoginCredentials, RegisterData, User } from "../types/auth"

// Dummy user data for testing
const dummyUsers: User[] = [
  {
    id: "1",
    firstName: "John",
    lastName: "Doe",
    username: "johndoe",
    role: "student",
  },
  {
    id: "2",
    firstName: "Jane",
    lastName: "Smith",
    username: "janesmith",
    role: "professor",
  },
]

export async function login(credentials: LoginCredentials): Promise<{ user: User; token: string } | null> {
  // Simulate API call
  await new Promise((resolve) => setTimeout(resolve, 1000))

  const user = dummyUsers.find((u) => u.username === credentials.username)

  if (user) {
    // In a real app, you would validate the password here
    return { user, token: "dummy_token" }
  }

  return null
}

export async function register(data: RegisterData): Promise<User | null> {
  // Simulate API call
  await new Promise((resolve) => setTimeout(resolve, 1000))

  // In a real app, you would create a new user in the database
  const newUser: User = {
    id: String(dummyUsers.length + 1),
    firstName: data.firstName,
    lastName: data.lastName,
    username: data.username,
    role: data.role,
    telephone: data.telephone,
    profilePhotoUrl: data.profilePhoto ? URL.createObjectURL(data.profilePhoto) : undefined,
  }

  dummyUsers.push(newUser)
  return newUser
}

export function getUserFromToken(token: string): User | null {
  // In a real app, you would validate the token and fetch the user data
  // For this example, we'll just return the first user
  return dummyUsers[0]
}

export function logout() {
  localStorage.removeItem("authToken")
  localStorage.removeItem("userRole")
}

