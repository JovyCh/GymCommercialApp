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