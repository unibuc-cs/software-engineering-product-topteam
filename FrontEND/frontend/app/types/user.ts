import type { Group } from "./group";

export interface User {
  id: number;
  firstName: string;
  lastName: string;
  telephone: string;
  email: string;
  group: string;
  class: string;
  username: string;
  password: string;
  profilePhotoUrl: string;
  enrolledCourses: string[];
  addedGroups?: Group[];
}
