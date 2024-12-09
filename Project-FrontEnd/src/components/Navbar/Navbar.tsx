import React from "react";
import { Link } from "react-router-dom";
import styles from "./Dashboard.module.css";

const Dashboard: React.FC = () => {
  return (
    <div className={styles.dashboard}>
      <nav className={styles.navbar}>
        <Link to="/user" className={styles.navItem}>
          <i className={styles.icon}>👤</i>
          <span>Profil</span>
        </Link>
        <Link to="/notifications" className={styles.navItem}>
          <i className={styles.icon}>🔔</i>
          <span>Notificări</span>
        </Link>
        <Link to="/courses" className={styles.navItem}>
          <span>Cursuri</span>
        </Link>
        <Link to="/homework" className={styles.navItem}>
          <span>Teme</span>
        </Link>
        <Link to="/shop" className={styles.navItem}>
          <span>Shop</span>
        </Link>
      </nav>
    </div>
  );
};

export default Dashboard;
