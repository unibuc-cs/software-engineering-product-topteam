import CourseCard from "./CourseCard";

// This would typically come from an API or database
const courses = [
  {
    id: 1,
    title: "Introduction to React",
    description: "Learn the basics of React and build your first app",
    instructor: "Jane Doe",
    price: 49.99,
    imageUrl: "/placeholder.svg?height=200&width=300",
  },
  {
    id: 2,
    title: "Advanced JavaScript Concepts",
    description: "Deep dive into advanced JavaScript topics",
    instructor: "John Smith",
    price: 79.99,
    imageUrl: "/placeholder.svg?height=200&width=300",
  },
  {
    id: 3,
    title: "Full Stack Web Development",
    description: "Become a full stack developer with this comprehensive course",
    instructor: "Alice Johnson",
    price: 99.99,
    imageUrl: "/placeholder.svg?height=200&width=300",
  },
  {
    id: 4,
    title: "UI/UX Design Principles",
    description:
      "Master the art of creating beautiful and functional user interfaces",
    instructor: "Bob Williams",
    price: 59.99,
    imageUrl: "/placeholder.svg?height=200&width=300",
  },
  // Add more courses as needed
];

export default function CourseGrid() {
  return (
    <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-6">
      {courses.map((course) => (
        <CourseCard key={course.id} {...course} />
      ))}
    </div>
  );
}
