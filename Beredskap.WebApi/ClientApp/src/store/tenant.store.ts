import { makeObservable, observable, action } from 'mobx';
import tenantService from '../services/tenant/tenant.service';
import { INIT_TENANT, Tenant } from '../services/tenant/dto/tenant.dto';
import React from 'react';
import { AddTenantDTO } from '@/services/tenant/dto/add.tenant.dto';
import { naturalSortByProperty } from '../utils/sort.util';

class TenantStore {
    tenant: Tenant;
    tenants: Tenant[]  = [];

    constructor() {
        this.tenant = INIT_TENANT;
        this.tenants = [];
        makeObservable(this, {
            tenant: observable,
            tenants: observable,
            setTenant: action,
            setTenants: action,
            getTenants: action,
            getTenant: action,
            addTenant: action,
        });
    }

    setTenant(tenant: Tenant) {
        this.tenant = tenant;
    }

    async setTenants(tenants: Tenant[]) {
        this.tenants = tenants;
    }

    async getTenants(): Promise<void> {
        try {
            const result = await tenantService.getTenants();
            this.tenants = [...result];
        } catch(error) {
            console.log(error);
        }
    }

    async getTenant(id: string): Promise<void> {
        try {
            const result = await tenantService.getTenant(id);
            this.tenant = {...result};
        } catch(error) {
            console.log(error);
        }
    }

    async addTenant(model: AddTenantDTO): Promise<void> {
        try {
            const result = await tenantService.addTenant(model);
        
            let tenants = [...this.tenants, result];
            this.tenants = tenants; 
        } catch(error) {
            console.log(error);
        }
    }
}

const tenantStore = new TenantStore();
export default tenantStore;

export const TenantStoreContext = React.createContext(new TenantStore());
