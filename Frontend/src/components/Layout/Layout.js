import React from 'react';
import Navbar from './Navbar';
import Footer from './Footer';
import { useTheme } from '../../context/ThemeContext';

const Layout = ({ children }) => {
  const { theme } = useTheme();
  
  return (
    <div className={`d-flex flex-column min-vh-100 ${theme === 'dark' ? 'bg-dark text-light' : 'bg-light text-dark'}`}>
      <Navbar />
      <main className="flex-grow-1">
        {children}
      </main>
      <Footer />
    </div>
  );
};

export default Layout; 