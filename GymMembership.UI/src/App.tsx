import { BrowserRouter as Router, Routes, Route, Link } from 'react-router-dom';
import MemberList from './pages/MemberList';
import AdminList from './pages/AdminList';
import InstructorList from './pages/InstructorList';
import RegisterInstructorForm from './pages/RegisterInstructor';
import CreateAdminCommandForm from './pages/RegisterAdmin';
import RegisterMemberForm from './pages/RegisterMember';
import LoginForm from './pages/LoginForm';
import HomePage from './pages/HomePage';


function App() {
  return (
    <Router>
      <nav style={{ 
        padding: '15px 30px', 
        background: '#1a1a1a', 
        display: 'flex', 
        gap: '25px', 
        fontFamily: 'sans-serif' 
      }}>
        <Link to="/" style={{ color: 'white', textDecoration: 'none', fontWeight: 'bold' }}>
          📝 Login
        </Link>

        <Link to="/home" style={{ color: 'white', textDecoration: 'none', fontWeight: 'bold' }}>
          Home
        </Link>

        <Link to="/register" style={{ color: 'white', textDecoration: 'none', fontWeight: 'bold' }}>
          📝 Register Member
        </Link>

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
      </nav>

      <Routes>
        <Route path="/" element={< LoginForm />} />
        
        <Route path="/home" element={< HomePage />} />

        <Route path="/register" element={<RegisterMemberForm />} />
        
        <Route path="/members" element={<MemberList />} />

        <Route path="/admin" element={<AdminList />} />

        <Route path="/instructor" element={<InstructorList />} />

        <Route path="/instructor/register" element={<RegisterInstructorForm />} />
        
        <Route path="/admin/register" element={<CreateAdminCommandForm />} />

      </Routes>
    </Router>
  );
}

export default App;