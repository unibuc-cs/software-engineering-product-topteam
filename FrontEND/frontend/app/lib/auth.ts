import type { LoginCredentials, RegisterData, User } from "../types/auth";

const API_BASE_URL = "http://localhost:5081/api";

export async function login(
  credentials: LoginCredentials
): Promise<{ user: User; token: string; message: string } | null> {
  try {
    console.log("Sending login request with credentials:", credentials);

    const response = await fetch(`${API_BASE_URL}/User/login`, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(credentials),
    });

    if (!response.ok) {
      throw new Error("Login failed");
    }

    const data = await response.json();
    console.log("Received login response:", data);

    // Ensure profesorVerificat is a boolean
    const profesorVerificat = data.profesorVerificat === true;

    const user: User = {
      username: credentials.username,
      profesorVerificat: profesorVerificat,
      // Add other user properties as needed
      nume: data.nume || "",
      prenume: data.prenume || "",
      nivel: data.nivel || "",
      pozaProfil: data.pozaProfil || "",
      email: data.email || "",
      nrTelefon: data.nrTelefon || "",
    };

    console.log("Processed user data:", user);

    return {
      user,
      token: data.token,
      message: data.message,
    };
  } catch (error) {
    console.error("Login error:", error);
    return null;
  }
}

export async function register(data: RegisterData): Promise<User | null> {
  // ... (keep the existing register function)
}

export function getUserFromToken(token: string): User | null {
  // This function might need to be updated based on how your backend handles token validation
  // For now, we'll return null
  return null;
}

export function logout() {
  localStorage.removeItem("authToken");
  localStorage.removeItem("userRole");
}
