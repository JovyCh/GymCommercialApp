import { useAdmins } from '../hooks/useAdmin';

export default function AdminList() {
  const { admins, searchTerm, setSearchTerm, loading, handleSearch, handleDelete } = useAdmins();

  return (
    <div style={{ padding: '20px', fontFamily: 'sans-serif' }}>
      <h2>Gym Admins</h2>

      <form onSubmit={handleSearch} style={{ marginBottom: '20px', display: 'flex', gap: '10px' }}>
        <input 
          type="text" 
          value={searchTerm}
          onChange={(e) => setSearchTerm(e.target.value)}
          placeholder="Search admins..." 
        />
        <button type="submit">{loading ? 'Searching...' : 'Search'}</button>
      </form>

      <ul>
        {admins.map(admin => (
          <li key={admin.id}>
            <span>{admin.name} ({admin.email})</span>
            <button onClick={() => handleDelete(admin.id)}>Delete</button>
          </li>
        ))}
      </ul>
    </div>
  );
}