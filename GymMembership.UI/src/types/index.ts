export interface CreateMemberCommand {
  name: string;
  email: string;
  phone: string;
  address: string;
  emergencyContact: string;
  emergencyContactPhone: string;
  selectedPlanId: string;
  password: string;
}