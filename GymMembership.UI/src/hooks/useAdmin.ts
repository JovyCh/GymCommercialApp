import { useState, useEffect } from 'react';
import { adminApi } from '../api/adminApi'
import type { AdminDto } from '../types/AdminDto';

export function useAdmins() {
  const [admins, setAdmins] = useState<AdminDto[]>([]);

  useEffect(() => {
    adminApi.list().then(setAdmins).catch(console.error);
  }, []);

  return { admins };
}