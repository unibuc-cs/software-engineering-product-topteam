import { Suspense } from "react";
import CourseGrid from "@/components/Courses/CourseGrid";
import FilterSidebar from "@/components/Courses/FilterSidebar";
import { Input } from "@/components/ui/input";
import { Search } from "lucide-react";

export default function ShopPage() {
  return (
    <div className="flex-1 flex flex-col">
      <header className="border-b">
        <div className="container mx-auto py-4 px-6">
          <h1 className="text-2xl font-bold">Course Shop</h1>
        </div>
      </header>
      <div className="container mx-auto px-6 py-8 flex-1 flex flex-col md:flex-row gap-8">
        <aside className="w-full md:w-64 flex-shrink-0">
          <div className="sticky top-4">
            <div className="relative mb-6">
              <Search className="absolute left-2 top-2.5 h-4 w-4 text-muted-foreground" />
              <Input placeholder="   Search courses" className="pl-9 " />
            </div>
            <FilterSidebar />
          </div>
        </aside>
        <main className="flex-1">
          <Suspense fallback={<div>Loading courses...</div>}>
            <CourseGrid />
          </Suspense>
        </main>
      </div>
    </div>
  );
}
