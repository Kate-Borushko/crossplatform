export interface Facility {
  id: number;
  name: string;
  type: string;
  columnType: string;
  temperatureTop: number;
  temperatureBottom: number;
  pressureTop: number;
  employeeId?: number;
}

export interface CreateFacilityRequest {
  name: string;
  type: string;
  columnType: string;
  temperatureTop: number;
  temperatureBottom: number;
  pressureTop: number;
}
