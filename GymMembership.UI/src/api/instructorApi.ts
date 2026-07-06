import axiosInstance from './axiosConfig';
import type { AxiosResponse } from 'axios';
import type { InstructorDto, RegisterInstructorCommand } from '../types/InstructorDto';

export const instructorApi = {
  list: () => 
    axiosInstance.get<InstructorDto[]>('/Instructor/getInstructors')
      .then((res: AxiosResponse<InstructorDto[]>) => res.data),

  create: (cmd: RegisterInstructorCommand) =>
    axiosInstance.post<string>('/Instructor/registerInstructor', cmd)
      .then((res: AxiosResponse<string>) => res.data),

  delete: (id: string) => 
    axiosInstance.delete<void>(`/Instructor/instructorDelete/${id}`)
      .then((res: AxiosResponse<void>) => res.data),

   search: (params: { name?: string}) =>
    axiosInstance.get<InstructorDto[]>('/Instructor/searchInstructor' , {params})
      .then((res: AxiosResponse<InstructorDto[]>) => res.data),
};