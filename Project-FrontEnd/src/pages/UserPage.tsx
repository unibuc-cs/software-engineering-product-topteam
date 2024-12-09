import { Avatar, AvatarFallback, AvatarImage } from "@/components/ui/avatar";
import { Button } from "@/components/ui/button";
import { Card } from "@/components/ui/card";
import { Tabs, TabsContent, TabsList, TabsTrigger } from "@/components/ui/tabs";
import { BookOpen, GraduationCap, BarChart, Clock } from "lucide-react";

// This would typically come from your API or database
const user = {
  name: "Alice Johnson",
  email: "alice@example.com",
  avatar: "/placeholder.svg?height=100&width=100",
  enrolledCourses: 4,
  completedCourses: 2,
};

// Define courses with progress and lessons
const courses = [
  {
    id: 1,
    title: "Introduction to React",
    progress: 0,
    totalLessons: 10,
    completedLessons: 10,
  },
  {
    id: 2,
    title: "Advanced TypeScript",
    progress: 0,
    totalLessons: 15,
    completedLessons: 9,
  },
  {
    id: 3,
    title: "Node.js Fundamentals",
    progress: 0,
    totalLessons: 12,
    completedLessons: 4,
  },
  {
    id: 4,
    title: "GraphQL Mastery",
    progress: 100,
    totalLessons: 8,
    completedLessons: 0,
  },
];

// Recent activity data
const recentActivity = [
  {
    id: 1,
    action: "Completed lesson",
    course: "Introduction to React",
    time: "2 hours ago",
  },
  {
    id: 2,
    action: "Started course",
    course: "GraphQL Mastery",
    time: "1 day ago",
  },
  {
    id: 3,
    action: "Submitted assignment",
    course: "Advanced TypeScript",
    time: "3 days ago",
  },
];

// Function to calculate total progress based on courses' progress
const calculateTotalProgress = (courses: Array<any>) => {
  const totalLessons = courses.reduce(
    (sum, course) => sum + course.totalLessons,
    0
  );
  const weightedProgress = courses.reduce(
    (sum, course) => sum + course.progress * course.totalLessons,
    0
  );
  return totalLessons > 0 ? Math.round(weightedProgress / totalLessons) : 0;
};

// Calculate total progress dynamically
const totalProgress = calculateTotalProgress(courses);

export default function UserPage() {
  return (
    <div className="container py-6">
      <div className="row g-4">
        <div className="col-md-6">
          <div className="card">
            <div className="card-header d-flex align-items-center gap-4">
              <Avatar className="h-16 w-16">
                <AvatarImage alt={user.name} src={user.avatar} />
                <AvatarFallback>
                  {user.name
                    .split(" ")
                    .map((n) => n[0])
                    .join("")}
                </AvatarFallback>
              </Avatar>
              <div>
                <h5 className="card-title">{user.name}</h5>
                <p className="card-text">{user.email}</p>
              </div>
            </div>
            <div className="card-body">
              <div className="d-flex flex-column gap-2">
                <div className="d-flex align-items-center gap-2">
                  <BookOpen className="h-4 w-4 text-muted" />
                  <span>Enrolled Courses: {user.enrolledCourses}</span>
                </div>
                <div className="d-flex align-items-center gap-2">
                  <GraduationCap className="h-4 w-4 text-muted" />
                  <span>Completed Courses: {user.completedCourses}</span>
                </div>
                <div className="d-flex align-items-center gap-2">
                  <BarChart className="h-4 w-4 text-muted" />
                  <span>Overall Progress: {totalProgress}%</span>
                </div>
              </div>
            </div>
          </div>
        </div>

        <div className="col-md-6">
          <div className="card">
            <div className="card-header">
              <h5 className="card-title">Overall Progress</h5>
            </div>
            <div className="card-body">
              <div className="progress">
                <div
                  className="progress-bar bg-dark"
                  role="progressbar"
                  style={{ width: `${totalProgress}%` }}
                  aria-valuenow={totalProgress}
                  aria-valuemin="0"
                  aria-valuemax="100"
                ></div>
              </div>
              <span>{totalProgress}%</span>
            </div>
          </div>
        </div>
      </div>

      <Tabs defaultValue="courses" className="mt-4">
        <TabsList className="nav nav-pills">
          <TabsTrigger
            value="courses"
            className="nav-link btn btn-light text-dark custom-tab-btn"
            activeClassName="active"
          >
            Enrolled Courses
          </TabsTrigger>
          <TabsTrigger
            value="activity"
            className="nav-link btn btn-light text-dark custom-tab-btn"
            activeClassName="active"
          >
            Recent Activity
          </TabsTrigger>
        </TabsList>

        <TabsContent value="courses">
          <div className="row g-4">
            {courses.map((course) => (
              <div className="col-md-6" key={course.id}>
                <div className="card">
                  <div className="card-header">
                    <h5 className="card-title">{course.title}</h5>
                    <p className="card-text">
                      {course.completedLessons} of {course.totalLessons} lessons
                      completed
                    </p>
                  </div>
                  <div className="card-body">
                    <div className="progress">
                      <div
                        className="progress-bar bg-dark"
                        role="progressbar"
                        style={{ width: `${course.progress}%` }}
                        aria-valuenow={course.progress}
                        aria-valuemin="0"
                        aria-valuemax="100"
                      ></div>
                    </div>
                    <div className="mt-2 small text-muted">
                      {course.progress}% complete
                    </div>
                  </div>
                </div>
              </div>
            ))}
          </div>
        </TabsContent>

        <TabsContent value="activity">
          <div className="card">
            <div className="card-header">
              <h5 className="card-title">Recent Activity</h5>
            </div>
            <div className="card-body">
              <ul className="list-group">
                {recentActivity.map((activity) => (
                  <li
                    key={activity.id}
                    className="list-group-item d-flex align-items-center gap-4"
                  >
                    <Clock className="h-4 w-4 text-muted" />
                    <div>
                      <p className="small fw-semibold">{activity.action}</p>
                      <p className="small text-muted">{activity.course}</p>
                    </div>
                    <span className="ms-auto small text-muted">
                      {activity.time}
                    </span>
                  </li>
                ))}
              </ul>
            </div>
          </div>
        </TabsContent>
      </Tabs>
    </div>
  );
}
