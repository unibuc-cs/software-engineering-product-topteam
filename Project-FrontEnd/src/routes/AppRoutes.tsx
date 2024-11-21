import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import LoginPage from "../pages/LoginPage";
import RegisterPage from "../pages/RegisterPage";
import LoginFormPage from "../pages/LoginFormPage";

const AppRoutes = () => {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<LoginPage />} />
        <Route path="/register" element={<RegisterPage />} />
        <Route path="/login" element={<LoginFormPage />} />
        {/* Add more routes here */}
      </Routes>
    </Router>
  );
};

export default AppRoutes;
