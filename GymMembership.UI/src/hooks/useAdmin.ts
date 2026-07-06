import { useState, useEffect } from 'react';
import { adminApi } from '../api/adminApi'
import type { AdminDto } from '../types/AdminDto';

export function useAdmins() {
  const [admins, setAdmins] = useState<AdminDto[]>([]);
  const [searchTerm, setSearchTerm] = useState('');
  const [loading, setLoading] = useState(false);

  useEffect(() => {
    adminApi.list().then(setAdmins).catch(console.error);
  }, []);

  const handleSearch = async (e: React.FormEvent) => {
    e.preventDefault();
    setLoading(true);
    try {
      const results = searchTerm.trim() 
        ? await adminApi.search({ name: searchTerm }) 
        : await adminApi.list();
      setAdmins(results);
    } catch (err) {
      console.error(err);
    } finally {
      setLoading(false);
    }
  };

  const handleDelete = async (id: string) => {
    if(!window.confirm("Delete Admin")) {
      return;
    }

    try{
      await adminApi.delete(id);
      setAdmins(prev => prev.filter(a => a.id !== id));
    }
    catch (err) {
      console.error(err);
    }
  }

  return { admins, searchTerm, setSearchTerm, loading, handleSearch, handleDelete};
}