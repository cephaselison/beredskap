export interface Tenant {
  id: string;
  key: string;
  isActive: boolean;
}

export const INIT_TENANT: Tenant = {
  id: '',
  key: '',
  isActive: false
};