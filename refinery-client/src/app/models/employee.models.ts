import { Facility } from "./facility.models"; 

export interface Employee {
  id: number;
  name: string;
  surname: string;
  position: string;
  shift: string;
  phoneNumber: number;
  facilities?: Facility[];
}

export interface CreateEmployeeRequest { 
  name: string;
  surname: string;
  position: string;
  shift: string;
  phoneNumber: number;
}
