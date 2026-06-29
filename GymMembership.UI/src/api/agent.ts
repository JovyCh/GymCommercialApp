import axios from 'axios';
import type { AxiosResponse } from 'axios';
import type { CreateMemberCommand } from '../types';

axios.defaults.baseURL = 'https://localhost:7224/api'; 

const responseBody = <T>(response: AxiosResponse<T>) => response.data;

const requests = {
  get: <T>(url: string) => axios.get<T>(url).then(responseBody),
  post: <T>(url: string, body: {}) => axios.post<T>(url, body).then(responseBody),
};

const Members = {
  create: (command: CreateMemberCommand) => requests.post<string>('/Members/register', command),
};

const agent = {
  Members,
};

export default agent;