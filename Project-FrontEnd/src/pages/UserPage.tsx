import { Avatar, AvatarFallback, AvatarImage } from "@/components/ui/avatar";
import { Button } from "@/components/ui/button";
import {
  Card,
  CardContent,
  CardDescription,
  CardHeader,
  CardTitle,
} from "@/components/ui/card";
import { Progress } from "@/components/ui/progress";
import { Tabs, TabsContent, TabsList, TabsTrigger } from "@/components/ui/tabs";
import { BookOpen, GraduationCap, BarChart, Clock } from "lucide-react";

// This would typically come from your API or database
const user = {
  name: "Alice Johnson",
  email: "alice@example.com",
  avatar: "/placeholder.svg?height=100&width=100",
  enrolledCourses: 4,
  completedCourses: 2,
  totalProgress: 65,
};

const courses = [
  {
    id: 1,
    title: "Introduction to React",
    progress: 100,
    totalLessons: 10,
    completedLessons: 10,
  },
  {
    id: 2,
    title: "Advanced TypeScript",
    progress: 60,
    totalLessons: 15,
    completedLessons: 9,
  },
  {
    id: 3,
    title: "Node.js Fundamentals",
    progress: 30,
    totalLessons: 12,
    completedLessons: 4,
  },
  {
    id: 4,
    title: "GraphQL Mastery",
    progress: 0,
    totalLessons: 8,
    completedLessons: 0,
  },
];

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

export default function UserPage() {
  return (
    <div className="container mx-auto p-6">
      <div className="grid gap-6 md:grid-cols-2">
        <Card>
          <CardHeader className="flex flex-row items-center gap-4">
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
              <CardTitle>{user.name}</CardTitle>
              <CardDescription>{user.email}</CardDescription>
            </div>
          </CardHeader>
          <CardContent>
            <div className="grid gap-2">
              <div className="flex items-center gap-2">
                <BookOpen className="h-4 w-4 text-muted-foreground" />
                <span>Enrolled Courses: {user.enrolledCourses}</span>
              </div>
              <div className="flex items-center gap-2">
                <GraduationCap className="h-4 w-4 text-muted-foreground" />
                <span>Completed Courses: {user.completedCourses}</span>
              </div>
              <div className="flex items-center gap-2">
                <BarChart className="h-4 w-4 text-muted-foreground" />
                <span>Overall Progress: {user.totalProgress}%</span>
              </div>
            </div>
          </CardContent>
        </Card>
        <Card>
          <CardHeader>
            <CardTitle>Overall Progress</CardTitle>
          </CardHeader>
          <CardContent>
            <Progress value={user.totalProgress} className="w-full" />
          </CardContent>
        </Card>
      </div>
      <Tabs defaultValue="courses" className="mt-6">
        <TabsList>
          <TabsTrigger value="courses">Enrolled Courses</TabsTrigger>
          <TabsTrigger value="activity">Recent Activity</TabsTrigger>
        </TabsList>
        <TabsContent value="courses">
          <div className="grid gap-4 md:grid-cols-2">
            {courses.map((course) => (
              <Card key={course.id}>
                <CardHeader>
                  <CardTitle>{course.title}</CardTitle>
                  <CardDescription>
                    {course.completedLessons} of {course.totalLessons} lessons
                    completed
                  </CardDescription>
                </CardHeader>
                <CardContent>
                  <Progress value={course.progress} className="w-full" />
                  <div className="mt-2 text-sm text-muted-foreground">
                    {course.progress}% complete
                  </div>
                </CardContent>
              </Card>
            ))}
          </div>
        </TabsContent>
        <TabsContent value="activity">
          <Card>
            <CardHeader>
              <CardTitle>Recent Activity</CardTitle>
            </CardHeader>
            <CardContent>
              <ul className="space-y-4">
                {recentActivity.map((activity) => (
                  <li key={activity.id} className="flex items-center gap-4">
                    <Clock className="h-4 w-4 text-muted-foreground" />
                    <div>
                      <p className="text-sm font-medium">{activity.action}</p>
                      <p className="text-sm text-muted-foreground">
                        {activity.course}
                      </p>
                    </div>
                    <span className="ml-auto text-sm text-muted-foreground">
                      {activity.time}
                    </span>
                  </li>
                ))}
              </ul>
            </CardContent>
          </Card>
        </TabsContent>
      </Tabs>
    </div>
  );
}
