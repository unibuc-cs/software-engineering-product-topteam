"use client";

import Link from "next/link";
import { usePathname, useRouter } from "next/navigation";
import {
  User,
  MessageSquare,
  BookOpen,
  FileText,
  ShoppingCart,
  LogOut,
  Plus,
  Users,
} from "lucide-react";
import type { User as UserType } from "../types/auth";
import { logout } from "../lib/auth";

const studentNavItems = [
  { name: "User", href: "/user", icon: User },
  { name: "Chat", href: "/chat", icon: MessageSquare },
  { name: "Enrolled Courses", href: "/enrolled-courses", icon: BookOpen },
  { name: "Homework", href: "/homework", icon: FileText },
  { name: "Shop", href: "/shop", icon: ShoppingCart },
];

const professorNavItems = [
  { name: "User", href: "/professor/user", icon: User },
  { name: "Chat", href: "/professor/chat", icon: MessageSquare },
  { name: "Your Created Courses", href: "/professor/courses", icon: BookOpen },
  { name: "Create a Course", href: "/professor/create-course", icon: Plus },
  { name: "Create Group", href: "/professor/create-group", icon: Users },
  {
    name: "Assign Homework",
    href: "/professor/assign-homework",
    icon: FileText,
  },
];

interface NavbarProps {
  user: UserType;
}

export function Navbar({ user }: NavbarProps) {
  const pathname = usePathname();
  const router = useRouter();
  const navItems =
    user.nivel === "student" ? studentNavItems : professorNavItems;

  const handleLogout = () => {
    logout();
    router.push("/login");
  };

  return (
    <nav className="w-64 bg-white shadow-lg">
      <div className="p-4">
        <h1 className="text-2xl font-bold text-gray-800">Course Website</h1>
        <p className="mt-2 text-sm text-gray-600">Welcome, {user.prenume}</p>
      </div>
      <ul className="space-y-2 p-4">
        {navItems.map((item) => (
          <li key={item.name}>
            <Link
              href={item.href}
              className={`flex items-center p-2 rounded-lg ${
                pathname === item.href
                  ? "bg-blue-100 text-blue-600"
                  : "text-gray-600 hover:bg-gray-100"
              }`}
            >
              <item.icon className="w-5 h-5 mr-3" />
              {item.name}
            </Link>
          </li>
        ))}
        <li>
          <button
            onClick={handleLogout}
            className="flex items-center p-2 rounded-lg text-gray-600 hover:bg-gray-100 w-full"
          >
            <LogOut className="w-5 h-5 mr-3" />
            Log Out
          </button>
        </li>
      </ul>
    </nav>
  );
}
