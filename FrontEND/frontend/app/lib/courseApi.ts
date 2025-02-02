import type { Course } from "../types/course";

const BASE_URL = "http://localhost:5081/api"; // Replace with your actual base URL

export async function getAllCourses(): Promise<Course[]> {
  const response = await fetch(`${BASE_URL}/Curs`);
  if (!response.ok) {
    throw new Error("Failed to fetch courses");
  }
  return response.json();
}

export async function getCourse(cursId: number): Promise<Course> {
  const response = await fetch(`${BASE_URL}/Curs/${cursId}`);
  if (!response.ok) {
    throw new Error("Failed to fetch course");
  }
  return response.json();
}

export async function createCourse(
  course: Omit<Course, "cursId">
): Promise<Course> {
  const response = await fetch(`${BASE_URL}/Curs`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(course),
  });
  if (!response.ok) {
    throw new Error("Failed to create course");
  }
  return response.json();
}

export async function updateCourse(course: Course): Promise<Course> {
  const response = await fetch(`${BASE_URL}/Curs/${course.cursId}`, {
    method: "PUT",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(course),
  });
  if (!response.ok) {
    throw new Error("Failed to update course");
  }
  return response.json();
}

export async function deleteCourse(cursId: number): Promise<void> {
  const response = await fetch(`${BASE_URL}/Curs/${cursId}`, {
    method: "DELETE",
  });
  if (!response.ok) {
    throw new Error("Failed to delete course");
  }
}
