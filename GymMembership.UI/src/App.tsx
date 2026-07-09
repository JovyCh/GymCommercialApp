import { BrowserRouter as Router, Routes, Route, Link } from 'react-router-dom';
import MemberList from './pages/MemberList';
import AdminList from './pages/AdminList';
import InstructorList from './pages/InstructorList';
import RegisterInstructorForm from './pages/RegisterInstructor';
import CreateAdminCommandForm from './pages/RegisterAdmin';
import RegisterMemberForm from './pages/RegisterMember';
import LoginForm from './pages/LoginForm';
import HomePage from './pages/HomePage';
import { useState, useEffect } from 'react';
import ScheduledClasses from './pages/ScheduledClasses';
import UserMenu from './components/UI/UserMenu';

function App() {
  const [userType, setUserType] = useState<string | null>(null);

  useEffect(() => {
    const savedRole = localStorage.getItem('userType');
    if (savedRole) setUserType(savedRole);
  }, []);
  return (

    <Router>
      <nav style={{ 
        padding: '15px 30px', 
        background: '#1a1a1a', 
        display: 'flex', 
        gap: '25px', 
        fontFamily: 'sans-serif' 
      }}>
        {!userType && (
          <>
          <Link to="/" style={{ color: 'white', textDecoration: 'none', fontWeight: 'bold' }}>
            📝 Login
          </Link>

          <Link to="/register" style={{ color: 'white', textDecoration: 'none', fontWeight: 'bold' }}>
          📝 Register Member
          </Link>
          </>
        )}

        {userType && (
          <Link to="/home" style={{ color: 'white', textDecoration: 'none', fontWeight: 'bold' }}>
            Home
          </Link>
        )}
        
        {userType === 'Instructor' && (
            <Link to="/classes" style={{ color: 'white', textDecoration: 'none', fontWeight: 'bold' }}>
            📋 View Classes List
          </Link>
        )}

        {userType === 'Admin' && (
          <>
          <Link to="/members" style={{ color: 'white', textDecoration: 'none', fontWeight: 'bold' }}>
            📋 View Member List
          </Link>

          <Link to="/admin" style={{ color: 'white', textDecoration: 'none', fontWeight: 'bold' }}>
            📋 View Admin List
          </Link>

          <Link to="/instructor" style={{ color: 'white', textDecoration: 'none', fontWeight: 'bold' }}>
            📋 View Instructor List
          </Link>

          <Link to="/instructor/register" style={{ color: 'white', textDecoration: 'none', fontWeight: 'bold' }}>
            📝 Register Instructor
          </Link>

          <Link to="/admin/register" style={{ color: 'white', textDecoration: 'none', fontWeight: 'bold' }}>
            📝 Create Admin
          </Link>
          </>
        )}

      {userType && (
        <UserMenu 
          userType={userType} 
          onLogout={() => {
            localStorage.clear();
            setUserType(null);
            window.location.href = '/';
          }} 
        />
      )}
      </nav>

      <Routes>
        <Route path="/" element={<LoginForm onLoginSuccess={(role) => setUserType(role)} />} />
        
        <Route path="/home" element={userType ? <HomePage /> :< HomePage />} />

        <Route path="/register" element={<RegisterMemberForm />} />
        
        <Route path="/members" element={<MemberList />} />

        <Route path="/admin" element={<AdminList />} />

        <Route path="/instructor" element={<InstructorList />} />

        <Route path="/classes" element= {<ScheduledClasses />} />

        <Route path="/instructor/register" element={<RegisterInstructorForm />} />
        
        <Route path="/admin/register" element={<CreateAdminCommandForm />} />

      </Routes>
    </Router>
  );
}

export default App;