export interface User {
  id?: string;
  username: string;
  profesorVerificat: boolean;
  nume: string;
  prenume: string;
  nivel: string;
  pozaProfil: string;
  email: string;
  nrTelefon: string;
  // Add other user properties as needed
}

export interface LoginCredentials {
  username: string;
  parola: string;
  remember: boolean;
}

export interface RegisterData {
  parola: string;
  nume: string;
  prenume: string;
  username: string;
  nivel: string;
  pozaProfil: string;
  email: string;
  nrTelefon: string;
  profesorVerificat: boolean;
}

export interface AuthState {
  user: User | null;
  token: string | null;
}
