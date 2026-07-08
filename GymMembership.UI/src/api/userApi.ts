import { axiosInstance } from './axiosConfig';
import type { UserDto, LoginResponse } from '../types/UserDto';
// Make sure LoginResponse is imported here if it's in a separate DTO file!

export const userApi = {
  login: (cmd: UserDto) => {
    return axiosInstance
      .post<LoginResponse>('/User/Login', cmd)
      .then((res) => res.data);
  },
};