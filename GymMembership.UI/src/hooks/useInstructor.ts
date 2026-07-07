import { useState, useEffect } from 'react';
import { instructorApi } from '../api/instructorApi'
import type { InstructorDto } from '../types/InstructorDto';

export function useInstructors() {
  const [instructors, setInstructors] = useState<InstructorDto[]>([]);
  const [searchTerm, setSearchTerm] = useState('');
  const [loading, setLoading] = useState(false);

  useEffect(() => {
    instructorApi.list().then(setInstructors).catch(console.error);
  }, []);

  const handleSearch = async (e:React.FormEvent) => {
    e.preventDefault();
    setLoading(true);
    try{
      const results = searchTerm.trim()
       ? await instructorApi.search({name:searchTerm})
       : await instructorApi.list();
      setInstructors(results);
    }
    catch(err){
      console.error(err);
    }
    finally{
      setLoading(false);
    }
  }

  const handleDelete = async (id: string) => {
    if (!window.confirm("Delete instructor?")) {
      return;
    }
    try {
      await instructorApi.delete(id);
      setInstructors(prev => prev.filter(i => i.id !== id));
    } 
    catch (err) {
      console.error(err);
    }
  };

  return { instructors, searchTerm, setSearchTerm, loading, handleSearch, handleDelete};
}