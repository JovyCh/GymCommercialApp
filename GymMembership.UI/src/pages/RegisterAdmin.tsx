import type { CreateAdminCommand } from "../types/AdminDto";
import { useState } from 'react';
import agent from '../api/agent';

function CreateAdminCommandForm() {
  const [name, setName] = useState("");
  const [email, setEmail] = useState("");
  const [phone, setPhone] = useState("");
  const [address, setAddress] = useState("");
  const [emergencyContact, setEmergencyContact] = useState("");
  const [emergencyContactPhone, setEmergencyContactPhone] = useState("");
  const [level, setLevel] = useState(1);
  const [password, setPassword] = useState("");

  const [loading, setLoading] = useState(false);
  const [message, setMessage] = useState<{ text: string; isError: boolean } | null>(null);

  const handleSubmit = async (e: React.SyntheticEvent) => {
    e.preventDefault();
    setLoading(true);
    setMessage(null);

    const command: CreateAdminCommand = {
      name: "Whassip",
      email,
      phone,
      address,
      emergencyContact,
      emergencyContactPhone,
      level,
      password
    };

    try {
      await agent.Admin.create(command);
      setMessage({ text: `Successfully created admin: ${name}!`, isError: false });
      setName('');
      setEmail('');
      setPhone('');
      setAddress('');
      setEmergencyContact('');
      setEmergencyContactPhone('');
      setLevel(1);
      setPassword('');
    } catch (err) {
      console.error(err);
      setMessage({ text: 'Failed to create admin account.', isError: true });
    } finally {
      setLoading(false);
    }
  };

  return (
    <div style={{ maxWidth: '400px', margin: '40px auto', padding: '20px', fontFamily: 'sans-serif', border: '1px solid #ddd', borderRadius: '8px', color: 'white' }}>
      <h2>Gym Admin Creation</h2>
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
          <label style={{ display: 'block', marginBottom: '5px' }}>Account Password</label>
          <input type="password" value={password} onChange={(e) => setPassword(e.target.value)} required style={{ width: '100%', padding: '8px', boxSizing: 'border-box' }} />
        </div>

        <div>
          <label style={{ display: 'block', marginBottom: '5px' }}>Emergency Contact</label>
          <input type="text" value={emergencyContact} onChange={(e) => setEmergencyContact(e.target.value)} required style={{ width: '100%', padding: '8px', boxSizing: 'border-box' }} />
        </div>
        
        <div>
          <label style={{ display: 'block', marginBottom: '5px' }}>Emergency Contact Phone Number</label>
          <input type="text" value={emergencyContactPhone} onChange={(e) => setEmergencyContactPhone(e.target.value)} required style={{ width: '100%', padding: '8px', boxSizing: 'border-box' }} />
        </div>

        <div>
          <label style={{ display: 'block', marginBottom: '5px' }}>Admin Level</label>
          <input type="number" min="1" max="5" value={level} onChange={(e) => setLevel(e.target.valueAsNumber || 1)} required style={{ width: '100%', padding: '8px', boxSizing: 'border-box' }} />
        </div>

        <button type="submit" disabled={loading} style={{ padding: '10px', backgroundColor: '#28a745', color: 'white', border: 'none', borderRadius: '4px', cursor: loading ? 'not-allowed' : 'pointer', marginTop: '10px' }}>
          {loading ? 'Processing...' : 'Create Admin Account'}
        </button>
      </form>
    </div>
  );
}

export default CreateAdminCommandForm;