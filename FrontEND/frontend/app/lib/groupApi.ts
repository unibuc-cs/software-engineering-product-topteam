import type { Group } from "../types/group";

const BASE_URL = "http://localhost:5081/api"; // Replace with your actual base URL

export async function getAllGroups(): Promise<Group[]> {
  const response = await fetch(`${BASE_URL}/Grupa`);
  if (!response.ok) {
    throw new Error("Failed to fetch groups");
  }
  return response.json();
}

export async function getGroup(id: number): Promise<Group> {
  const response = await fetch(`${BASE_URL}/Grupa/${id}`);
  if (!response.ok) {
    throw new Error("Failed to fetch group");
  }
  return response.json();
}

export async function createGroup(group: Omit<Group, "id">): Promise<Group> {
  const response = await fetch(`${BASE_URL}/Grupa`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(group),
  });
  if (!response.ok) {
    throw new Error("Failed to create group");
  }
  return response.json();
}

export async function updateGroup(group: Group): Promise<Group> {
  const response = await fetch(`${BASE_URL}/Grupa/${group.id}`, {
    method: "PUT",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(group),
  });
  if (!response.ok) {
    throw new Error("Failed to update group");
  }
  return response.json();
}

export async function deleteGroup(id: number): Promise<void> {
  const response = await fetch(`${BASE_URL}/Grupa/${id}`, {
    method: "DELETE",
  });
  if (!response.ok) {
    throw new Error("Failed to delete group");
  }
}
