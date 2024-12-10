import {
  Card,
  CardContent,
  CardFooter,
  CardHeader,
  CardTitle,
} from "@/components/ui/card";
import { Button } from "@/components/ui/button";
import { Img } from "react-image";
import { Link } from "react-router-dom"; // Importăm Link

interface CourseCardProps {
  title: string;
  description: string;
  instructor: string;
  price: number;
  imageUrl: string;
}

export default function CourseCard({
  title,
  description,
  instructor,
  price,
  imageUrl,
}: CourseCardProps) {
  const slug = title.toLowerCase().replace(/\s+/g, "-"); // Creăm un slug din titlu

  return (
    <Card className="flex flex-col h-full">
      <CardHeader className="p-0">
        <div className="aspect-video relative">
          <Img
            src={imageUrl}
            alt={title}
            className="object-cover rounded-t-lg w-full h-full"
          />
        </div>
      </CardHeader>
      <CardContent className="flex-grow p-4">
        <Link to={`/shop/${slug}`}>
          <CardTitle className="mb-2 hover:underline text-blue-600">
            {title}
          </CardTitle>
        </Link>
        <p className="text-sm text-muted-foreground mb-2">{description}</p>
        <p className="text-sm font-medium">Instructor: {instructor}</p>
      </CardContent>
      <CardFooter className="p-4 flex justify-between items-center">
        <span className="text-lg font-bold">${price.toFixed(2)}</span>
        <Button>Add to Cart</Button>
      </CardFooter>
    </Card>
  );
}
