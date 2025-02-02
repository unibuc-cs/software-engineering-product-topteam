import type { Group } from "../types/group";

const BASE_URL = "http://localhost:5081/api";

export async function getUserEnrolledGroups(): Promise<Group[]> {
  const userId = localStorage.getItem("userId");
  if (!userId) {
    throw new Error("User ID not found");
  }

  const response = await fetch(`${BASE_URL}/User/getAddedGroups?id=${userId}`);
  if (!response.ok) {
    throw new Error("Failed to fetch user's enrolled groups");
  }
  return response.json();
}
