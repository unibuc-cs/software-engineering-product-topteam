import React from "react";
import RegisterForm from "../components/RegisterForm/RegisterForm";

const RegisterPage = () => {
  return (
    <div className="login-page">
      <div className="content-box">
        <h1>Register</h1>
        <RegisterForm />
      </div>
    </div>
  );
};

export default RegisterPage;
