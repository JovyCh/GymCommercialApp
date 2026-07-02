import axiosInstance from './axiosConfig';
import type { AxiosResponse } from 'axios';
import type { MemberDto, CreateMemberCommand } from '../types/MemberDto';

export const membersApi = {
  list: () => 
    axiosInstance.get<MemberDto[]>('/Members/getMembers')
      .then((res: AxiosResponse<MemberDto[]>) => res.data),

  create: (cmd: CreateMemberCommand) => 
    axiosInstance.post<string>('/Members/register', cmd)
      .then((res: AxiosResponse<string>) => res.data),

  delete: (id: string) => 
    axiosInstance.delete<void>(`/Members/memberDelete/${id}`)
      .then((res: AxiosResponse<void>) => res.data),

  search: (params: { name?: string }) => 
    axiosInstance.get<MemberDto[]>('/Members/search', { params })
      .then((res: AxiosResponse<MemberDto[]>) => res.data),
};