import './UserMenu.css';

interface UserMenuProps {
  userType: string;
  onLogout: () => void;
}

export default function UserMenu({ userType, onLogout }: UserMenuProps) {
  const roleClass = userType.toLowerCase();

  return (
    <div className="user-menu-container">
      <span className="user-menu-text">
        Logged in as:{' '}
        <strong className={`user-badge ${roleClass}`}>
          {userType}
        </strong>
      </span>

      <button onClick={onLogout} className="logout-button">
        Logout
      </button>
    </div>
  );
}