"use client";

import { useNavigate } from "react-router-dom";
import { Img } from "react-image";
import { Tabs, TabsContent, TabsList, TabsTrigger } from "@/components/ui/tabs";
import { Button } from "@/components/ui/button";
import { Progress } from "@/components/ui/progress";
import { Avatar, AvatarFallback, AvatarImage } from "@/components/ui/avatar";
import {
  Card,
  CardContent,
  CardDescription,
  CardHeader,
  CardTitle,
} from "@/components/ui/card";
import { Badge } from "@/components/ui/badge";
import { CheckCircle, Clock, PlayCircle, Users, ArrowLeft } from "lucide-react";
import { useParams } from "react-router-dom";

// This would typically come from an API or database based on the slug
const courses = [
  {
    slug: "introduction-to-react",
    title: "Introduction to React",
    description: "Learn the basics of React and build your first app",
    instructor: {
      name: "Jane Doe",
      avatar: "/placeholder.svg?height=40&width=40",
      bio: "Experienced frontend developer and React expert.",
    },
    price: 49.99,
    imageUrl: "/placeholder.svg?height=400&width=800",
    rating: 4.5,
    totalStudents: 1500,
    totalHours: 10,
    totalLectures: 20,
    topics: ["JSX", "Components", "Props", "State", "Hooks", "Routing"],
    curriculum: [
      { title: "Getting Started with React", lectures: 4, duration: "1h 30m" },
      { title: "Components and Props", lectures: 5, duration: "2h" },
      { title: "State and Lifecycle", lectures: 6, duration: "2h 30m" },
      { title: "Hooks and Custom Hooks", lectures: 5, duration: "2h" },
    ],
    subscriptionPlans: [
      { name: "Monthly", price: 14.99, period: "month" },
      { name: "Yearly", price: 149.99, period: "year", discount: "17%" },
    ],
  },
  // Add more courses here
];

export default function CourseTemplatePage() {
  const { slug } = useParams(); // Preluăm slug-ul din URL
  const course = courses.find((c) => c.slug === slug); // Căutăm cursul în lista de date
  const navigate = useNavigate();

  if (!course) {
    return <div className="container mx-auto px-6 py-8">Course not found!</div>;
  }

  return (
    <div className="flex-1 flex flex-col">
      <header className="bg-gray-100 border-b">
        <div className="container mx-auto py-8 px-6">
          <Button
            variant="ghost"
            onClick={() => navigate("/dashboard/shop")}
            className="mb-4"
          >
            <ArrowLeft className="mr-2 h-4 w-4" /> Back to Shop
          </Button>
          <h1 className="text-3xl font-bold mb-2">{course.title}</h1>
          <p className="text-xl text-muted-foreground mb-4">
            {course.description}
          </p>
          <div className="flex items-center space-x-4">
            <span className="flex items-center">
              <Users className="w-5 h-5 mr-2" />
              {course.totalStudents} students
            </span>
            <span className="flex items-center">
              <Clock className="w-5 h-5 mr-2" />
              {course.totalHours} hours
            </span>
            <span className="flex items-center">
              <PlayCircle className="w-5 h-5 mr-2" />
              {course.totalLectures} lectures
            </span>
            <span className="flex items-center">
              <Badge variant="secondary">{course.rating} ★</Badge>
            </span>
          </div>
        </div>
      </header>
      <div className="container mx-auto px-6 py-8 flex-1 flex flex-col lg:flex-row gap-8">
        <main className="flex-1">
          <Tabs defaultValue="overview" className="w-full">
            <TabsList>
              <TabsTrigger value="overview">Overview</TabsTrigger>
              <TabsTrigger value="curriculum">Curriculum</TabsTrigger>
              <TabsTrigger value="instructor">Instructor</TabsTrigger>
            </TabsList>
            <TabsContent value="overview">
              <Card>
                <CardHeader>
                  <CardTitle>What you'll learn</CardTitle>
                </CardHeader>
                <CardContent>
                  <ul className="grid grid-cols-1 md:grid-cols-2 gap-2">
                    {course.topics.map((topic, index) => (
                      <li key={index} className="flex items-start">
                        <CheckCircle className="w-5 h-5 mr-2 text-green-500 flex-shrink-0" />
                        <span>{topic}</span>
                      </li>
                    ))}
                  </ul>
                </CardContent>
              </Card>
            </TabsContent>
            <TabsContent value="curriculum">
              <Card>
                <CardHeader>
                  <CardTitle>Course Curriculum</CardTitle>
                  <CardDescription>
                    {course.totalLectures} lectures • {course.totalHours} hours
                  </CardDescription>
                </CardHeader>
                <CardContent>
                  {course.curriculum.map((section, index) => (
                    <div key={index} className="mb-4">
                      <h3 className="font-semibold mb-2">{section.title}</h3>
                      <div className="flex justify-between text-sm text-muted-foreground">
                        <span>{section.lectures} lectures</span>
                        <span>{section.duration}</span>
                      </div>
                      <Progress value={(index + 1) * 25} className="mt-2" />
                    </div>
                  ))}
                </CardContent>
              </Card>
            </TabsContent>
            <TabsContent value="instructor">
              <Card>
                <CardHeader>
                  <div className="flex items-center space-x-4">
                    <Avatar>
                      <AvatarImage
                        src={course.instructor.avatar}
                        alt={course.instructor.name}
                      />
                      <AvatarFallback>
                        {course.instructor.name
                          .split(" ")
                          .map((n) => n[0])
                          .join("")}
                      </AvatarFallback>
                    </Avatar>
                    <div>
                      <CardTitle>{course.instructor.name}</CardTitle>
                      <CardDescription>Course Instructor</CardDescription>
                    </div>
                  </div>
                </CardHeader>
                <CardContent>
                  <p>{course.instructor.bio}</p>
                </CardContent>
              </Card>
            </TabsContent>
          </Tabs>
        </main>
        <aside className="w-full lg:w-80 flex-shrink-0">
          <div className="sticky top-4">
            <Card>
              <CardContent className="p-6">
                <div className="aspect-video relative mb-4">
                  <Img
                    src={course.imageUrl}
                    alt={course.title}
                    className="object-cover rounded-lg"
                  />
                </div>
                <div className="space-y-4">
                  {course.subscriptionPlans.map((plan, index) => (
                    <div
                      key={index}
                      className="flex justify-between items-center"
                    >
                      <div>
                        <h3 className="font-semibold">{plan.name}</h3>
                        <p className="text-sm text-muted-foreground">
                          ${plan.price}/{plan.period}
                        </p>
                      </div>
                      <Button>Subscribe</Button>
                    </div>
                  ))}
                </div>
                <p className="text-center text-sm text-muted-foreground mt-4">
                  30-Day Money-Back Guarantee
                </p>
                <div className="mt-6 space-y-2">
                  <h4 className="font-semibold">This course includes:</h4>
                  <ul className="space-y-1">
                    <li className="flex items-center text-sm">
                      <PlayCircle className="w-4 h-4 mr-2" />
                      {course.totalHours} hours on-demand video
                    </li>
                    <li className="flex items-center text-sm">
                      <Users className="w-4 h-4 mr-2" />
                      Full lifetime access
                    </li>
                    <li className="flex items-center text-sm">
                      <CheckCircle className="w-4 h-4 mr-2" />
                      Certificate of completion
                    </li>
                  </ul>
                </div>
              </CardContent>
            </Card>
          </div>
        </aside>
      </div>
    </div>
  );
}
