import { Checkbox } from "@/components/ui/checkbox";
import { Label } from "@/components/ui/label";

const categories = [
  "Web Development",
  "Mobile Development",
  "Data Science",
  "Machine Learning",
  "DevOps",
  "Design",
];

export default function FilterSidebar() {
  return (
    <div className="space-y-4">
      <h2 className="text-lg font-semibold mb-4">Categories</h2>
      {categories.map((category) => (
        <div key={category} className="flex items-center space-x-2">
          <Checkbox id={category} />
          <Label htmlFor={category}>{category}</Label>
        </div>
      ))}
    </div>
  );
}
