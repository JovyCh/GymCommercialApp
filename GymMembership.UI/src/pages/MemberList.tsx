import { useMembers } from '../hooks/useMembers';

export default function MemberList() {
  const { members, searchTerm, setSearchTerm, loading, handleSearch, handleDelete } = useMembers();

  return (
    <div style={{ padding: '20px', fontFamily: 'sans-serif' }}>
      <h2>Gym Members</h2>

      <form onSubmit={handleSearch} style={{ marginBottom: '20px', display: 'flex', gap: '10px' }}>
        <input 
          type="text" 
          value={searchTerm}
          onChange={(e) => setSearchTerm(e.target.value)}
          placeholder="Search members..." 
        />
        <button type="submit">{loading ? 'Searching...' : 'Search'}</button>
      </form>

      <ul>
        {members.map(member => (
          <li key={member.id}>
            <span>{member.name} ({member.email})</span>
            <button onClick={() => handleDelete(member.id)}>Delete</button>
          </li>
        ))}
      </ul>
    </div>
  );
}