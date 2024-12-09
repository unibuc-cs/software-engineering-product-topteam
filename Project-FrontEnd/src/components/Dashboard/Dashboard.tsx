import React from "react";
import { Link, Outlet } from "react-router-dom";
import {
  FiUser,
  FiBell,
  FiBook,
  FiClipboard,
  FiShoppingCart,
} from "react-icons/fi";

const Dashboard: React.FC = () => {
  return (
    <div className="d-flex vh-100">
      {/* Navbar fix și centrat */}
      <nav
        className="bg-dark text-white d-flex flex-column align-items-center justify-content-center p-3"
        style={{ width: "80px" }}
      >
        <ul className="nav flex-column text-center">
          <li className="nav-item mb-4">
            <Link
              to="/dashboard/user"
              className="text-white text-decoration-none"
              style={{ transition: "0.3s", opacity: "1" }}
              onMouseOver={(e) => (e.currentTarget.style.opacity = "0.7")}
              onMouseOut={(e) => (e.currentTarget.style.opacity = "1")}
            >
              <FiUser size={24} />
              <p className="small mt-2">User</p>
            </Link>
          </li>
          <li className="nav-item mb-4">
            <Link
              to="/dashboard/notifications"
              className="text-white text-decoration-none"
              style={{ transition: "0.3s", opacity: "1" }}
              onMouseOver={(e) => (e.currentTarget.style.opacity = "0.7")}
              onMouseOut={(e) => (e.currentTarget.style.opacity = "1")}
            >
              <FiBell size={24} />
              <p className="small mt-2">Notificări</p>
            </Link>
          </li>
          <li className="nav-item mb-4">
            <Link
              to="/dashboard/courses"
              className="text-white text-decoration-none"
              style={{ transition: "0.3s", opacity: "1" }}
              onMouseOver={(e) => (e.currentTarget.style.opacity = "0.7")}
              onMouseOut={(e) => (e.currentTarget.style.opacity = "1")}
            >
              <FiBook size={24} />
              <p className="small mt-2">Cursuri</p>
            </Link>
          </li>
          <li className="nav-item mb-4">
            <Link
              to="/dashboard/homework"
              className="text-white text-decoration-none"
              style={{ transition: "0.3s", opacity: "1" }}
              onMouseOver={(e) => (e.currentTarget.style.opacity = "0.7")}
              onMouseOut={(e) => (e.currentTarget.style.opacity = "1")}
            >
              <FiClipboard size={24} />
              <p className="small mt-2">Teme</p>
            </Link>
          </li>
          <li className="nav-item mb-4">
            <Link
              to="/dashboard/shop"
              className="text-white text-decoration-none"
              style={{ transition: "0.3s", opacity: "1" }}
              onMouseOver={(e) => (e.currentTarget.style.opacity = "0.7")}
              onMouseOut={(e) => (e.currentTarget.style.opacity = "1")}
            >
              <FiShoppingCart size={24} />
              <p className="small mt-2">Shop</p>
            </Link>
          </li>
        </ul>
      </nav>

      {/* Conținutul principal */}
      <div className="flex-grow-1 p-4 bg-light">
        <Outlet />
      </div>
    </div>
  );
};

export default Dashboard;
