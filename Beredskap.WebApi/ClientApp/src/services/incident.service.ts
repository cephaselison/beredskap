import { IncidentDTO } from "@/dto/incident/Incident.dto";
import http from "./httpService";

class IncidentService {
  public async getIncidents() {
    try {
       let result = await http.get(`api/Incidents`, {
                headers: {
                'tenant': localStorage.getItem("tenantId"),
                'Authorization': `Bearer ${localStorage.getItem('access_token')}`
            },
            });
            return result.data;
    } catch (error) {
      console.log(error);
    }
  }

    public async getIncident(id: string) {
    try {
       let result = await http.get(`api/Incident/${id}`, {
                headers: {
                'tenant': localStorage.getItem("tenantId"),
                'Authorization': `Bearer ${localStorage.getItem('access_token')}`
            },
            });
            return result.data;
    } catch (error) {
      console.log(error);
    }
  }

  public async addIncident(model: IncidentDTO) {
        try {
      let result = await http.put('api/Incidents', model, {
                headers: {
                'tenant': localStorage.getItem("tenantId"),
                'Authorization': `Bearer ${localStorage.getItem('access_token')}`
            },
            });
      return result.data;
    } catch (error) {
        console.log(error);
    }
  }

}

export default new IncidentService();