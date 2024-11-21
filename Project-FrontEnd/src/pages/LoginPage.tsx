import React from "react";
import Button from "../components/Button";
import { Route, useNavigate } from "react-router-dom";

const LoginPage = () => {
  const navigate = useNavigate();

  const handleLogin = () => {
    navigate("/login");
  };

  const handleRegister = () => {
    navigate("/register");
  };

  return (
    <div
      style={{
        display: "flex",
        flexDirection: "column",
        alignItems: "center",
        justifyContent: "center",
        height: "100vh",
        backgroundColor: "#f5f5f5",
      }}
    >
      <h1>InvataOnlineDe10</h1>
      <Button onClick={handleLogin}>Login</Button>
      <Button onClick={handleRegister}>Register</Button>
    </div>
  );
};

export default LoginPage;
