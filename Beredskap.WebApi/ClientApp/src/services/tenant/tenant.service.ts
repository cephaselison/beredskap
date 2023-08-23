import { Tenant } from "./dto/tenant.dto";
import http from '../httpService';
import { AddTenantDTO } from "./dto/add.tenant.dto";

class TenantService {
  public async getTenants () {
    try {
      let result = await http.get('api/Tenants', {
                headers: {
                'tenant': 'user',
                'Authorization': `Bearer ${localStorage.getItem('access_token')}`
            },
            });
      return result.data;
    } catch (error) {
        console.log(error);
    }
  }

  public async addTenant(model: AddTenantDTO) {
        try {
      let result = await http.post('api/Tenants', model, {
                headers: {
                'tenant': 'user',
                'Authorization': `Bearer ${localStorage.getItem('access_token')}`
            },
            });
      return result.data;
    } catch (error) {
        console.log(error);
    }
  }

    public async getTenant(id: string) {
        try {
      let result = await http.get(`api/Tenants/${id}`, {
                headers: {
                'tenant': 'user',
                'Authorization': `Bearer ${localStorage.getItem('access_token')}`
            },
            });
      return result.data;
    } catch (error) {
        console.log(error);
    }
  }
}

export default new TenantService();