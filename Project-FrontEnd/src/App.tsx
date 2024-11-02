// src/App.tsx
import React from "react";
import Header from "./components/Header";
import Container from "@mui/material/Container";
import Typography from "@mui/material/Typography";
import Box from "@mui/material/Box";

const App: React.FC = () => {
  return (
    <div>
      <Header />
      <Container maxWidth="md">
        <Box mt={4} mb={4} textAlign="center">
          <Typography variant="h4" component="h1" gutterBottom>
            Bine ai venit în aplicația mea!
          </Typography>
          <Typography variant="body1">
            Acesta este conținutul principal al paginii. Folosește Container și
            Box pentru a organiza secțiunile și a le centra.
          </Typography>
          {/* Adaugă mai multe componente și conținut după nevoie */}
        </Box>
      </Container>
    </div>
  );
};

export default App;
