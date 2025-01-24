import React from 'react';
import { useTheme } from '../context/ThemeContext';

const ThemeToggle = () => {
  const { theme, toggleTheme } = useTheme();

  return (
    <button 
      onClick={toggleTheme} 
      className={`btn ${theme === 'dark' ? 'btn-light' : 'btn-dark'} btn-sm`}
    >
      {theme === 'light' ? '🌙' : '☀️'} {theme === 'light' ? 'Dark' : 'Light'} Mode
    </button>
  );
};

export default ThemeToggle; 