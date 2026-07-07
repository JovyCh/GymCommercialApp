import axios from 'axios';
import { instructorApi } from './instructorApi';
import { membersApi } from './membersApi';
import { adminApi } from './adminApi';

export const axiosInstance = axios.create({
  baseURL: 'https://localhost:7224/api',
});

const agent = {
  Admin: adminApi,
  Members: membersApi,
  Instructor: instructorApi
};

export default agent;