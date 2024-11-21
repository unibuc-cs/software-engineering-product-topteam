import LoginForm from "../components/LoginForm/LoginForm";

const LoginFormPage = () => {
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
      <h1>Login</h1>
      <LoginForm />
    </div>
  );
};

export default LoginFormPage;
