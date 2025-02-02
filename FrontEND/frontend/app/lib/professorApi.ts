import type { Group } from "../types/group";

const BASE_URL =
  process.env.NEXT_PUBLIC_API_BASE_URL || "http://localhost:5081/api";

export async function getAllGroups(): Promise<Group[]> {
  const response = await fetch(`${BASE_URL}/Grupa`);
  if (!response.ok) {
    throw new Error("Failed to fetch groups");
  }
  return response.json();
}

export async function assignHomework(
  userId: number,
  title: string,
  description: string
): Promise<void> {
  const response = await fetch(`${BASE_URL}/Tema`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({
      titlu: title,
      descriere: description,
      fisier: "",
      userId: userId,
    }),
  });

  if (!response.ok) {
    throw new Error("Failed to assign homework");
  }
}
