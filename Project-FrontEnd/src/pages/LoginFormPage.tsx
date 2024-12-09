import LoginForm from "../components/LoginForm/LoginForm";
import { useNavigate } from "react-router-dom";

const LoginFormPage = () => {
  return (
    <div className="login-page">
      <div className="content-box">
        <h1>Login</h1>
        <LoginForm />
      </div>
    </div>
  );
};

export default LoginFormPage;
