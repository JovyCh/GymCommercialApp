import { useState, useEffect } from 'react';
import { scheduledClassApi } from '../api/scheduledClassApi';
import type { ScheduledClassesDto } from '../types/ScheduledClasses';

export function useScheduledClasses(){
    const [scheduledClasses, setScheduledClasses] = useState<ScheduledClassesDto[]>([]);
    
    useEffect(() => {
        scheduledClassApi.list().then(setScheduledClasses).catch(console.error);
    },[]);

    return { scheduledClasses }
}