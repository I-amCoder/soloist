import React from 'react';
import { useTheme } from '../../context/ThemeContext';

const Footer = () => {
  const { theme } = useTheme();
  
  return (
    <footer className={`py-4 ${theme === 'dark' ? 'bg-dark text-light' : 'bg-light text-dark'} mt-auto`}>
      <div className="container">
        <div className="row">
          <div className="col-md-6">
            <h5>ACM Chapter</h5>
            <p className="mb-0">Advancing Computing as a Science & Profession</p>
          </div>
          <div className="col-md-6 text-md-end">
            <p className="mb-0">© 2024 ACM. All rights reserved.</p>
          </div>
        </div>
      </div>
    </footer>
  );
};

export default Footer; 