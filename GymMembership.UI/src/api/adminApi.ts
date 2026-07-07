import { axiosInstance } from './axiosConfig';
import type { AxiosResponse } from 'axios';
import type { AdminDto, CreateAdminCommand } from '../types/AdminDto';

export const adminApi = {
  list: () => 
    axiosInstance.get<AdminDto[]>('/Admin/getAdmins')
      .then((res: AxiosResponse<AdminDto[]>) => res.data),

  create: (cmd: CreateAdminCommand) =>
    axiosInstance.post<string>('Admin/adminRegister', cmd)
      .then((res: AxiosResponse<string>) => res.data),

  delete: (id:string) =>
    axiosInstance.delete<void>(`/Admin/deleteAdmin/${id}`)
      .then((res: AxiosResponse<void>) => res.data),

  search: (params: { name?: string }) => 
    axiosInstance.get<AdminDto[]>('/Admin/searchAdmin', { params })
      .then((res: AxiosResponse<AdminDto[]>) => res.data),
};