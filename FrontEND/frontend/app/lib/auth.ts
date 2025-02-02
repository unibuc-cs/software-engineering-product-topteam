import type { LoginCredentials, RegisterData, User } from "../types/auth";

const API_BASE_URL = "http://localhost:5081/api";

export async function login(
  credentials: LoginCredentials
): Promise<{ token: string; message: string; userId: number } | null> {
  try {
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
    console.log("Login response:", data);

    return {
      token: data.token,
      message: data.message,
      userId: data.id,
    };
  } catch (error) {
    console.error("Login error:", error);
    return null;
  }
}

export async function getUserById(
  userId: number,
  token: string
): Promise<User | null> {
  try {
    const response = await fetch(
      `${API_BASE_URL}/User/getUserById?id=${userId}`,
      {
        method: "GET",
        headers: {
          Authorization: `Bearer ${token}`,
          "Content-Type": "application/json",
        },
      }
    );

    if (!response.ok) {
      const errorData = await response.json();
      console.error("Error response:", errorData);
      throw new Error(
        `Failed to fetch user data: ${response.status} ${response.statusText}`
      );
    }

    const userData = await response.json();
    console.log("User data:", userData);
    return userData;
  } catch (error) {
    console.error("Get user error:", error);
    throw error; // Re-throw the error to be handled by the caller
  }
}

export async function register(data: RegisterData): Promise<User | null> {
  try {
    const response = await fetch(`${API_BASE_URL}/User/register`, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(data),
    });

    if (!response.ok) {
      throw new Error("Registration failed");
    }

    const user = await response.json();
    return user;
  } catch (error) {
    console.error("Registration error:", error);
    return null;
  }
}

export function logout() {
  localStorage.removeItem("authToken");
  localStorage.removeItem("userId");
  localStorage.removeItem("userNivel");
}
