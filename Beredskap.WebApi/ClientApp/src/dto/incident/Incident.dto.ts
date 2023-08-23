import { GuidEmpty } from "../../constants/general";
import { INCIDENT_STATUS } from "../../enum/incident.status.enum";

export interface IncidentDTO {
  id: string;
  name: string;
  location: string;
  incidentStatus: INCIDENT_STATUS
}

export const INIT_INCIDENT: IncidentDTO = {
  id: GuidEmpty,
  name: '',
  location: '',
  incidentStatus: INCIDENT_STATUS.Unknown,
}