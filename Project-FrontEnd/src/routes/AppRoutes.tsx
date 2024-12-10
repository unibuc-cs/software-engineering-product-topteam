import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import LoginPage from "../pages/LoginPage";
import RegisterPage from "../pages/RegisterPage";
import LoginFormPage from "../pages/LoginFormPage";
import UserPage from "../pages/UserPage";
import NotificationsPage from "../pages/NotificationsPage";
import CoursesPage from "../pages/CoursesPage";
import HomeworkPage from "../pages/HomeworkPage";
import ShopPage from "../pages/ShopPage";
import DashboardPage from "../pages/DashboardPage";
import CourseTemplatePage from "../pages/CourseTemplatePage";

const AppRoutes = () => {
  return (
    <Router>
      <Routes>
        {/* Rutele care nu au navbar-ul */}
        <Route path="/" element={<LoginPage />} />
        <Route path="/register" element={<RegisterPage />} />
        <Route path="/login" element={<LoginFormPage />} />
        <Route path="/shop/:slug" element={<CourseTemplatePage />} />

        {/* Rutele care includ Dashboard (navbar-ul rămâne activ) */}
        <Route path="/dashboard" element={<DashboardPage />}>
          {/* Rutele interne ce vor fi încărcate în Dashboard */}
          <Route path="user" element={<UserPage />} />
          <Route path="notifications" element={<NotificationsPage />} />
          <Route path="courses" element={<CoursesPage />} />
          <Route path="homework" element={<HomeworkPage />} />
          <Route path="shop" element={<ShopPage />} />
          {/* Puteți adăuga o rută implicită dacă doriți */}
        </Route>
      </Routes>
    </Router>
  );
};

export default AppRoutes;
