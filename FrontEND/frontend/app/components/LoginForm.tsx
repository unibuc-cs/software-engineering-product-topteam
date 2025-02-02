"use client";

import { useState } from "react";
import { useForm } from "react-hook-form";
import { useRouter } from "next/navigation";
import type { LoginCredentials } from "../types/auth";
import { login, getUserById } from "../lib/auth";
import { Eye, EyeOff } from "lucide-react";

export function LoginForm() {
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<LoginCredentials>();
  const [showPassword, setShowPassword] = useState(false);
  const [error, setError] = useState<string | null>(null);
  const [message, setMessage] = useState<string | null>(null);
  const router = useRouter();

  const onSubmit = async (data: LoginCredentials) => {
    try {
      console.log("Submitting login data:", data);
      const result = await login(data);
      console.log("Login result:", result);
      if (result) {
        // Store the token and user ID in localStorage
        localStorage.setItem("authToken", result.token);
        localStorage.setItem("userId", result.userId.toString());
        setMessage(result.message);

        try {
          // Fetch user data
          const userData = await getUserById(result.userId, result.token);
          if (userData) {
            localStorage.setItem("userNivel", userData.nivel);
            // Redirect to the appropriate page based on the user's role after a short delay
            setTimeout(() => {
              router.push(
                userData.nivel === "student" ? "/shop" : "/professor/user"
              );
            }, 1500);
          } else {
            setError("Failed to fetch user data");
          }
        } catch (userError) {
          console.error("Error fetching user data:", userError);
          setError("Failed to fetch user data. Please try logging in again.");
        }
      } else {
        setError("Invalid username or password");
      }
    } catch (err) {
      console.error("Login error:", err);
      setError("An error occurred. Please try again.");
    }
  };

  return (
    <form onSubmit={handleSubmit(onSubmit)} className="space-y-4">
      <div>
        <label
          htmlFor="username"
          className="block text-sm font-medium text-gray-700"
        >
          Username
        </label>
        <input
          type="text"
          id="username"
          {...register("username", { required: "Username is required" })}
          className="mt-1 block w-full rounded-md border-gray-300 shadow-sm focus:border-indigo-300 focus:ring focus:ring-indigo-200 focus:ring-opacity-50"
        />
        {errors.username && (
          <p className="mt-1 text-sm text-red-600">{errors.username.message}</p>
        )}
      </div>
      <div>
        <label
          htmlFor="parola"
          className="block text-sm font-medium text-gray-700"
        >
          Password
        </label>
        <div className="relative">
          <input
            type={showPassword ? "text" : "password"}
            id="parola"
            {...register("parola", { required: "Password is required" })}
            className="mt-1 block w-full rounded-md border-gray-300 shadow-sm focus:border-indigo-300 focus:ring focus:ring-indigo-200 focus:ring-opacity-50"
          />
          <button
            type="button"
            onClick={() => setShowPassword(!showPassword)}
            className="absolute inset-y-0 right-0 flex items-center pr-3"
          >
            {showPassword ? (
              <EyeOff className="h-5 w-5 text-gray-400" />
            ) : (
              <Eye className="h-5 w-5 text-gray-400" />
            )}
          </button>
        </div>
        {errors.parola && (
          <p className="mt-1 text-sm text-red-600">{errors.parola.message}</p>
        )}
      </div>
      <div>
        <label htmlFor="remember" className="flex items-center">
          <input
            type="checkbox"
            id="remember"
            {...register("remember")}
            className="rounded border-gray-300 text-indigo-600 shadow-sm focus:border-indigo-300 focus:ring focus:ring-offset-0 focus:ring-indigo-200 focus:ring-opacity-50"
          />
          <span className="ml-2 text-sm text-gray-700">Remember me</span>
        </label>
      </div>
      {error && <p className="text-sm text-red-600">{error}</p>}
      {message && <p className="text-sm text-green-600">{message}</p>}
      <button
        type="submit"
        className="w-full py-2 px-4 border border-transparent rounded-md shadow-sm text-sm font-medium text-white bg-indigo-600 hover:bg-indigo-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500"
      >
        Log in
      </button>
    </form>
  );
}
