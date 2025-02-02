export interface User {
  id: number;
  username: string;
  nivel: string;
  nume: string;
  prenume: string;
  pozaProfil: string;
  email: string;
  nrTelefon: string;
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
}

export interface AuthState {
  user: User | null;
  token: string | null;
}
