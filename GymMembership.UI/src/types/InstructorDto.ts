export interface InstructorDto {
  id: string;
  name: string;
  email: string;
  phone: string;
  address: string;
  identityUserId: string;
  emergencyContact: string;
  emergencyContactPhone: string;
  certifications: [string];
  dateJoined?: string;
}

export interface RegisterInstructorCommand {
  name: string;
  email: string;
  phone: string;
  address: string;
  emergencyContact: string;
  emergencyContactPhone: string;
  password: string;
  certifications: string[];
}

export interface DeleteInstructorCommand {
  id: string;
}

export interface SearchInstructorCommand{
  id: string;
  name: string;
}