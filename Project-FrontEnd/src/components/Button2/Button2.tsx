import React from "react";
import styles from "./Button2.module.css";

interface Button2Props {
  onClick?: () => void;
  children: React.ReactNode;
  disabled?: boolean;
}

const Button2: React.FC<Button2Props> = ({ onClick, children, disabled }) => {
  return (
    <button
      className={`${styles.button} ${disabled ? styles.disabled : ""}`}
      onClick={onClick}
      disabled={disabled}
    >
      {children}
    </button>
  );
};

export default Button2;
