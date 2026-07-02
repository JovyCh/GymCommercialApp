import { useAdmins } from '../hooks/useAdmin'; // Double check if your file is useAdmin or useAdmins

export default function AdminList() {
  const { admins } = useAdmins();

  return (
    <div style={{ padding: '20px', fontFamily: 'sans-serif' }}>
      <h2>Gym Admins</h2>

      <ul>
        {admins.map(admin => (
          <li key={admin.id}>
            <span>{admin.name} ({admin.email})</span>
          </li>
        ))}
      </ul>
    </div>
  );
}