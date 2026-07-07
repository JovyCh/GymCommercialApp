import { useState, useEffect } from 'react';
import { membersApi } from '../api/membersApi';
import type { MemberDto } from '../types/MemberDto';

export function useMembers() {
  const [members, setMembers] = useState<MemberDto[]>([]);
  const [searchTerm, setSearchTerm] = useState('');
  const [loading, setLoading] = useState(false);

  useEffect(() => {
    membersApi.list().then(setMembers).catch(console.error);
  }, []);

  const handleSearch = async (e: React.FormEvent) => {
    e.preventDefault();
    setLoading(true);
    try {
      const results = searchTerm.trim() 
        ? await membersApi.search({ name: searchTerm }) 
        : await membersApi.list();
      setMembers(results);
    } 
    catch (err) {
      console.error(err);
    } 
    finally {
      setLoading(false);
    }
  };

  const handleDelete = async (id: string) => {
    if (!window.confirm("Delete member?")) {
      return;
    }
    try {
      await membersApi.delete(id);
      setMembers(prev => prev.filter(m => m.id !== id));
    } 
    catch (err) {
      console.error(err);
    }
  };

  return { members, searchTerm, setSearchTerm, loading, handleSearch, handleDelete };
}