import { useInstructors } from '../hooks/useInstructor'; 

export default function InstructorList() {
  const { instructors, searchTerm, setSearchTerm, loading, handleSearch, handleDelete } = useInstructors();

  return (
    <div style={{ padding: '20px', fontFamily: 'sans-serif' }}>
      <h2>Gym Instructors</h2>
      
      <form onSubmit={handleSearch}>
        <input
          type = "text"
          value = {searchTerm}
          onChange={(e) => setSearchTerm(e.target.value)}
          placeholder='Searching instructors.....'
        />
        <button type="submit">{loading ? 'Searching....' : 'Search'}</button>
      </form>

      <ul>
        {instructors.map(instructors => (
          <li key={instructors.id}>
            <span>{instructors.name} ({instructors.email})</span>
            <button onClick={() => handleDelete(instructors.id)}>Delete</button>
          </li>
        ))}
      </ul>
    </div>
  );
}