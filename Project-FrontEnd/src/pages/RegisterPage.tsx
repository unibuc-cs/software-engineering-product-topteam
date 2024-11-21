import React from "react";
import RegisterForm from "../components/RegisterForm/RegisterForm";

const RegisterPage = () => {
  return (
    <div
      style={{
        display: "flex",
        flexDirection: "column",
        alignItems: "center",
        justifyContent: "center",
        height: "100vh",
        backgroundColor: "#f5f5f5",
        padding: "20px",
      }}
    >
      <h1>Register</h1>
      <RegisterForm />
    </div>
  );
};

export default RegisterPage;
