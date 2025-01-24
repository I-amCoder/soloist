import React from 'react';
import Navbar from './Navbar';
import Footer from './Footer';
import { useTheme } from '../../context/ThemeContext';

const Layout = ({ children }) => {
  const { theme } = useTheme();
  
  return (
    <div 
      className="d-flex flex-column min-vh-100"
      style={{
        backgroundColor: 'var(--color-background)',
        color: 'var(--color-text)'
      }}
    >
      <Navbar />
      <main className="flex-grow-1">
        {children}
      </main>
      <Footer />
    </div>
  );
};

export default Layout; 