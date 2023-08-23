import { INIT_INCIDENT, IncidentDTO } from "../dto/incident/Incident.dto";
import incidentService from "../services/incident.service";
import { action, makeObservable, observable } from "mobx";
import React from "react";

class IncidentStore {
  incident: IncidentDTO;
  incidents: IncidentDTO[];

  constructor() {
    this.incident = INIT_INCIDENT;
    this.incidents = [];
    makeObservable(this, {
      incident: observable,
      incidents: observable,
      getIncidents: action,
      getIncident: action,
      addIncident: action,
    });
  }

  async getIncidents(): Promise<void> {
    try {
      const result = await incidentService.getIncidents();
      this.incidents = [...result];
    } catch (error) {
      
    }
  }

  async getIncident(id: string): Promise<void> {
    try {
      const result = await incidentService.getIncident(id);
      this.incident = {...result};
    } catch (error) {
      
    }
  }

  async addIncident(model: IncidentDTO): Promise<void> {
    try {
      const result = await incidentService.addIncident(model);
      this.incidents = [...this.incidents, result];
    } catch (error) {
      
    }
  }

}

const incidentStore = new IncidentStore();
export default incidentStore;
export const IncidentStoreContext = React.createContext(new IncidentStore());