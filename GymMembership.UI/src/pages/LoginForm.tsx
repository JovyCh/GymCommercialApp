import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import agent from '../api/agent';

interface LoginFormProps {
  onLoginSuccess: (role: string) => void;
}

function LoginForm({ onLoginSuccess }: LoginFormProps) {
  const navigate = useNavigate();
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const handleLogin = async (e: React.SyntheticEvent) => {
    e.preventDefault();
    setLoading(true);
    setError(null);

    try {
      const response = await agent.User.login({ email, password });

      if (response.isSuccess) {
        localStorage.setItem('token', response.token);
        localStorage.setItem('userType', response.userType);
        
        onLoginSuccess(response.userType);

        console.log("Login successful! Redirecting...");
        
        navigate('/home'); 
      } else {
        setError(response.errorMessage || "Invalid email or password.");
      }
    } 
    catch (err: any) 
    {
      if (err.response && err.response.data && err.response.data.message) {
          setError(err.response.data.message);
      } 
      else {
        setError("Something went wrong. Please try again.");
      }
    } 
    finally {
      setLoading(false);
    }
  };

  return (
    <div style={{ maxWidth: '350px', margin: '100px auto', padding: '30px', border: '1px solid #ddd', borderRadius: '8px', fontFamily: 'sans-serif' }}>
      <h2 style={{ textAlign: 'center', marginBottom: '20px' }}>Gym Management Login</h2>
      
      {error && (
        <div style={{ color: 'red', backgroundColor: '#fde8e8', padding: '10px', borderRadius: '4px', marginBottom: '15px' }}>
          {error}
        </div>
      )}

      <form onSubmit={handleLogin} style={{ display: 'flex', flexDirection: 'column', gap: '15px' }}>
        <div>
          <label style={{ display: 'block', marginBottom: '5px' }}>Email</label>
          <input type="email" value={email} onChange={e => setEmail(e.target.value)} required style={{ width: '100%', padding: '8px', boxSizing: 'border-box' }} />
        </div>
        <div>
          <label style={{ display: 'block', marginBottom: '5px' }}>Password</label>
          <input type="password" value={password} onChange={e => setPassword(e.target.value)} required style={{ width: '100%', padding: '8px', boxSizing: 'border-box' }} />
        </div>
        <button type="submit" disabled={loading} style={{ padding: '10px', backgroundColor: '#007bff', color: 'white', border: 'none', borderRadius: '4px', cursor: loading ? 'not-allowed' : 'pointer', fontWeight: 'bold' }}>
          {loading ? 'Signing In...' : 'Sign In'}
        </button>
      </form>
    </div>
  );
}

export default LoginForm;