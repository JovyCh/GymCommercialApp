export interface AdminDto {
  id: string;
  name: string;
  email: string;
  phone: string;
  address: string;
  identityUserId: string;
  emergencyContact: string;
  emergencyContactPhone: string;
  level: number;
  dateJoined?: string;
}

export interface CreateAdminCommand{
  name: string;
  email: string;
  phone: string;
  address: string;
  emergencyContact: string;
  emergencyContactPhone: string;
  level: number;
  password: string;
}

export interface SearchAdminCommand {
  id: string;
  name: string;
}

export interface DeleteAdminCommand{
  id: string;
}