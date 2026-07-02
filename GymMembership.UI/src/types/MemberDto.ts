export interface MemberDto {
  id: string;
  name: string;
  email: string;
  phone: string;
  address: string;
}

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

export interface DeleteMemberCommand {
  id: string;
}

export interface SearchMemberCommand {
  id: string;
  name: string;
}