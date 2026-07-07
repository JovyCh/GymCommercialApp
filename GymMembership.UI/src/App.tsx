import { useState } from 'react';
import agent from './api/axiosConfig';
import type { CreateMemberCommand } from './types/MemberDto';
import { BrowserRouter as Router, Routes, Route, Link } from 'react-router-dom';
import MemberList from './pages/MemberList';
import AdminList from './pages/AdminList';
import InstructorList from './pages/InstructorList';
import RegisterInstructorForm from './pages/RegisterInstructor';

function RegisterMemberForm() {
  const [name, setName] = useState('');
  const [email, setEmail] = useState('');
  const [phone, setPhone] = useState('');
  const [address, setAddress] = useState('');
  
  const [selectedPlanId, setSelectedPlanId] = useState(''); 
  const [password, setPassword] = useState('');

  const [loading, setLoading] = useState(false);
  const [message, setMessage] = useState<{ text: string; isError: boolean } | null>(null);

  const handleSubmit = async (e: React.SubmitEvent) => {
    e.preventDefault();
    setLoading(true);
    setMessage(null);

    const command: CreateMemberCommand = {
      name,
      email,
      phone,
      address,
      emergencyContact: "None Specified",
      emergencyContactPhone: "000-000-0000",
      selectedPlanId,
      password      
    };

    try {
      await agent.Members.create(command);
      setMessage({ text: `Successfully registered member: ${name}!`, isError: false });
      setName('');
      setEmail('');
      setPhone('');
      setAddress('');
      setSelectedPlanId('');
      setPassword('');
    } catch (err) {
      console.error(err);
      setMessage({ text: 'Failed to create member account. Check if the Plan ID is correct.', isError: true });
    } finally {
      setLoading(false);
    }
  };

  return (
    <div style={{ maxWidth: '400px', margin: '40px auto', padding: '20px', fontFamily: 'sans-serif', border: '1px solid #ddd', borderRadius: '8px' }}>
      <h2>Gym Member Registration</h2>
      <hr />

      {message && (
        <div style={{ padding: '10px', marginBottom: '15px', borderRadius: '4px', backgroundColor: message.isError ? '#fde8e8' : '#e1f5fe', color: message.isError ? '#e53935' : '#0288d1' }}>
          {message.text}
        </div>
      )}

      <form onSubmit={handleSubmit} style={{ display: 'flex', flexDirection: 'column', gap: '15px' }}>
        <div>
          <label style={{ display: 'block', marginBottom: '5px' }}>Full Name</label>
          <input type="text" value={name} onChange={(e) => setName(e.target.value)} required style={{ width: '100%', padding: '8px', boxSizing: 'border-box' }} />
        </div>

        <div>
          <label style={{ display: 'block', marginBottom: '5px' }}>Email Address</label>
          <input type="email" value={email} onChange={(e) => setEmail(e.target.value)} required style={{ width: '100%', padding: '8px', boxSizing: 'border-box' }} />
        </div>

        <div>
          <label style={{ display: 'block', marginBottom: '5px' }}>Phone Number</label>
          <input type="text" value={phone} onChange={(e) => setPhone(e.target.value)} required style={{ width: '100%', padding: '8px', boxSizing: 'border-box' }} />
        </div>

        <div>
          <label style={{ display: 'block', marginBottom: '5px' }}>Physical Address</label>
          <input type="text" value={address} onChange={(e) => setAddress(e.target.value)} required style={{ width: '100%', padding: '8px', boxSizing: 'border-box' }} />
        </div>

        <div>
          <label style={{ display: 'block', marginBottom: '5px' }}>Membership Plan ID (Guid)</label>
          <input type="text" value={selectedPlanId} onChange={(e) => setSelectedPlanId(e.target.value)} required style={{ width: '100%', padding: '8px', boxSizing: 'border-box' }} />
        </div>

        <div>
          <label style={{ display: 'block', marginBottom: '5px' }}>Account Password</label>
          <input type="password" value={password} onChange={(e) => setPassword(e.target.value)} required style={{ width: '100%', padding: '8px', boxSizing: 'border-box' }} />
        </div>

        <button type="submit" disabled={loading} style={{ padding: '10px', backgroundColor: '#28a745', color: 'white', border: 'none', borderRadius: '4px', cursor: loading ? 'not-allowed' : 'pointer' }}>
          {loading ? 'Processing...' : 'Create Gym Account'}
        </button>
      </form>
    </div>
  );
}

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
      </nav>

      <Routes>
        <Route path="/" element={<RegisterMemberForm />} />
        
        <Route path="/members" element={<MemberList />} />

        <Route path="/admin" element={<AdminList />} />

        <Route path="/instructor" element={<InstructorList />} />

        <Route path="/instructor/register" element={<RegisterInstructorForm />} />

      </Routes>
    </Router>
  );
}

export default App;