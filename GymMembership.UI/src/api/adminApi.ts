import axiosInstance from './axiosConfig';
import type { AxiosResponse } from 'axios';
import type { AdminDto } from '../types/AdminDto';

export const adminApi = {
  list: () => 
    axiosInstance.get<AdminDto[]>('/Admin/getAdmins')
      .then((res: AxiosResponse<AdminDto[]>) => res.data),

//   create: (cmd: CreateMemberCommand) => 
//     axiosInstance.post<string>('/Members/register', cmd)
//       .then((res: AxiosResponse<string>) => res.data),

//   delete: (id: string) => 
//     axiosInstance.delete<void>(`/Members/memberDelete/${id}`)
//       .then((res: AxiosResponse<void>) => res.data),

//   search: (params: { name?: string }) => 
//     axiosInstance.get<MemberDto[]>('/Members/search', { params })
//       .then((res: AxiosResponse<MemberDto[]>) => res.data),
};