// src/components/Header.tsx
import React, { useEffect, useState } from "react";
import AppBar from "@mui/material/AppBar";
import Toolbar from "@mui/material/Toolbar";
import Typography from "@mui/material/Typography";
import IconButton from "@mui/material/IconButton";
import Button from "@mui/material/Button";
import Box from "@mui/material/Box";
import Logo from "../assets/LogoHaiLaMate.png";

const Header: React.FC = () => {
  // State pentru a gestiona culoarea fundalului
  const [bgColor, setBgColor] = useState<string>("transparent");

  useEffect(() => {
    const handleScroll = () => {
      if (window.scrollY > 50) {
        // Ajustează valoarea pentru a schimba la un anumit punct
        setBgColor("#b3d4ff"); // Culoare neagră
      } else {
        setBgColor("transparent"); // Culoare transparentă
      }
    };

    window.addEventListener("scroll", handleScroll);

    // Curățare a event listener-ului la demontare
    return () => {
      window.removeEventListener("scroll", handleScroll);
    };
  }, []);

  return (
    <AppBar
      position="sticky"
      elevation={0}
      sx={{
        backgroundColor: bgColor, // Folosește culoarea din state
        color: "#4F9CF9",
        width: "100%",
        transition: "background-color 0.3s ease", // Adaugă o tranziție pentru schimbarea culorii
      }}
    >
      <Toolbar>
        <Box
          sx={{
            display: "flex",
            justifyContent: "space-between",
            alignItems: "center",
            maxWidth: "1200px",
            width: "100%",
            mx: "auto",
            fontFamily: '"Inter", sans-serif',
          }}
        >
          <IconButton
            edge="start"
            color="inherit"
            aria-label="home"
            sx={{ mr: 1 }}
          >
            <img src={Logo} alt="Logo" style={{ width: 120, height: 120 }} />
          </IconButton>

          <Typography
            variant="h6"
            component="div"
            sx={{ flexGrow: 1, color: "#0000FF" }}
          ></Typography>

          <Box sx={{ display: "flex", alignItems: "center", gap: 2 }}>
            <Button sx={{ fontFamily: '"Inter", sans-serif' }} color="inherit">
              Preț
            </Button>
            <Button sx={{ fontFamily: '"Inter", sans-serif' }} color="inherit">
              Povești de succes
            </Button>
            <Button sx={{ fontFamily: '"Inter", sans-serif' }} color="inherit">
              Contact
            </Button>
            <Button sx={{ fontFamily: '"Inter", sans-serif' }} color="inherit">
              Despre Noi
            </Button>

            <Button
              variant="contained"
              sx={{
                backgroundColor: "#FFE492",
                color: "black",
                borderRadius: "20px",
                fontFamily: '"Inter", sans-serif',
                "&:hover": {
                  backgroundColor: "#333333",
                  color: "white",
                },
                ml: 1,
              }}
            >
              Login/Register
            </Button>
          </Box>
        </Box>
      </Toolbar>
    </AppBar>
  );
};

export default Header;
