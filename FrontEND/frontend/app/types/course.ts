export interface Course {
  cursId: number;
  denumire: string;
  descriere: string;
  nrSedinte: number;
  pret: number;
}

// Keep the ProfessorMeeting interface as it might be useful for future features
export interface ProfessorMeeting {
  id: string;
  title: string;
  startingDay: string;
  startingHour: string;
  endingHour: string;
  class: string;
}
