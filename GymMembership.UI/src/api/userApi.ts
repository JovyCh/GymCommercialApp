import { axiosInstance } from './axiosConfig';
import type { UserDto, LoginResponse } from '../types/UserDto';

export const userApi = {
  login: (cmd: UserDto) => {
    return axiosInstance
      .post<LoginResponse>('/User/Login', cmd)
      .then((res) => res.data);
  },
};