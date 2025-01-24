import React, { createContext, useState, useEffect } from 'react';
import { login, register } from '../services/authService';

export const AuthContext = createContext();

export const AuthProvider = ({ children }) => {
  const [user, setUser] = useState(null);

  const handleLogin = async (email, password) => {
    const data = await login(email, password);
    setUser(data.user);
    localStorage.setItem('token', data.token);
  };

  const handleRegister = async (email, password) => {
    const data = await register(email, password);
    setUser(data.user);
    localStorage.setItem('token', data.token);
  };

  const handleLogout = () => {
    setUser(null);
    localStorage.removeItem('token');
  };

  useEffect(() => {
    const token = localStorage.getItem('token');
    if (token) {
      // Optionally, verify token and set user
    }
  }, []);

  return (
    <AuthContext.Provider value={{ user, handleLogin, handleRegister, handleLogout }}>
      {children}
    </AuthContext.Provider>
  );
}; 