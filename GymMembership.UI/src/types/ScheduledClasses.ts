import type { InstructorDto } from "./InstructorDto"; // Make sure your path is correct

export interface ScheduledClassesDto {
  id: string;
  name: string;
  room: string;
  description: string;
  startTime: string;
  maxCapacity: number;
  attendances: any[];
  appliedMembers: number;
  instructorId: string;
  instructor: InstructorDto | null;
  isCancelled: boolean;
  difficultyLevel: string;
  durationInMinutes: number;
}