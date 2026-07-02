import axios from 'axios';

const axiosInstance = axios.create({
  baseURL: 'https://localhost:7224/api',
});

export default axiosInstance;