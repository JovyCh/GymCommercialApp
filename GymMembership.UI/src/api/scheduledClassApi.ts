import { axiosInstance } from './axiosConfig';
import type { AxiosResponse } from 'axios';
import type { ScheduledClassesDto } from '../types/ScheduledClasses';

export const scheduledClassApi = {
    list: () =>
        axiosInstance.get<ScheduledClassesDto[]>('/ScheduledClass/getClasses')
        .then((res: AxiosResponse<ScheduledClassesDto[]>) => res.data)
}