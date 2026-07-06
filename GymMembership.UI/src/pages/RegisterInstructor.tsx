import type { RegisterInstructorCommand } from "../types/InstructorDto";
import { useState } from 'react';
import agent from '../api/axiosConfig';

function RegisterInstructorForm() {
  const [name, setName] = useState('');
  const [email, setEmail] = useState('');
  const [phone, setPhone] = useState('');
  const [address, setAddress] = useState('');
  
  const [selectedPlanId, setSelectedPlanId] = useState(''); 
  const [password, setPassword] = useState('');
  
  const [certifications, setCertifications] = useState<string[]>([]);
  const [certInput, setCertInput] = useState('');

  const [loading, setLoading] = useState(false);
  const [message, setMessage] = useState<{ text: string; isError: boolean } | null>(null);

  const handleAddCertification = () => {
    if (certInput.trim() !== '') {
      setCertifications([...certifications, certInput.trim()]);
      setCertInput('');
    }
  };

  const handleRemoveCertification = (indexToRemove: number) => {
    setCertifications(certifications.filter((_, index) => index !== indexToRemove));
  };

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    setLoading(true);
    setMessage(null);

    const command: RegisterInstructorCommand = {
      name,
      email,
      phone,
      address,
      emergencyContact: "None Specified",
      emergencyContactPhone: "000-000-0000",
      password,
      certifications
    };

    try {
      await agent.Instructor.create(command);
      setMessage({ text: `Successfully registered instructor: ${name}!`, isError: false });
      setName('');
      setEmail('');
      setPhone('');
      setAddress('');
      setSelectedPlanId('');
      setPassword('');
      setCertifications([]);
      setCertInput('');
    } catch (err) {
      console.error(err);
      setMessage({ text: 'Failed to create instructor account.', isError: true });
    } finally {
      setLoading(false);
    }
  };

  return (
    <div style={{ maxWidth: '400px', margin: '40px auto', padding: '20px', fontFamily: 'sans-serif', border: '1px solid #ddd', borderRadius: '8px' }}>
      <h2>Gym Instructor Registration</h2>
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

        <div>
          <label style={{ display: 'block', marginBottom: '5px' }}>Certifications</label>
          <div style={{ display: 'flex', gap: '8px' }}>
            <input 
              type="text" 
              placeholder="e.g. CPR Certified, Crossfit L1" 
              value={certInput} 
              onChange={(e) => setCertInput(e.target.value)} 
              style={{ flexGrow: 1, padding: '8px', boxSizing: 'border-box' }} 
            />
            <button 
              type="button" 
              onClick={handleAddCertification}
              style={{ padding: '8px 12px', cursor: 'pointer' }}
            >
              Add
            </button>
          </div>

          {certifications.length > 0 && (
            <ul style={{ paddingLeft: '20px', marginTop: '10px', fontSize: '14px', color: '#555' }}>
              {certifications.map((cert, index) => (
                <li key={index} style={{ marginBottom: '4px' }}>
                  <div style={{ display: 'flex', justifyContent: 'space-between', width: '100%' }}>
                    <span>{cert}</span>
                    <button 
                      type="button" 
                      onClick={() => handleRemoveCertification(index)} 
                      style={{ border: 'none', background: 'none', color: '#dc3545', cursor: 'pointer', fontWeight: 'bold', padding: '0 5px' }}
                    >
                      ✕
                    </button>
                  </div>
                </li>
              ))}
            </ul>
          )}
        </div>

        <button type="submit" disabled={loading} style={{ padding: '10px', backgroundColor: '#28a745', color: 'white', border: 'none', borderRadius: '4px', cursor: loading ? 'not-allowed' : 'pointer', marginTop: '10px' }}>
          {loading ? 'Processing...' : 'Create Instructor Account'}
        </button>
      </form>
    </div>
  );
}

export default RegisterInstructorForm;