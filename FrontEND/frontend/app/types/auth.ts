export interface User {
  id: string
  firstName: string
  lastName: string
  username: string
  role: "student" | "professor"
  profilePhotoUrl?: string
  telephone?: string
}

export interface LoginCredentials {
  username: string
  password: string
}

export interface RegisterData {
  firstName: string
  lastName: string
  username: string
  password: string
  role: "student" | "professor"
  profilePhoto?: File
  telephone?: string
}

export interface AuthState {
  user: User | null
  token: string | null
}

