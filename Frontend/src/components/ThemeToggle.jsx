import React from 'react';
import { useTheme } from '../context/ThemeContext';
import Button from './UI/Button';

const ThemeToggle = () => {
  const { theme, toggleTheme } = useTheme();

  return (
    <Button 
      variant="secondary"
      size="sm"
      onClick={toggleTheme}
    >
      {theme === 'light' ? '🌙' : '☀️'} {theme === 'light' ? 'Dark' : 'Light'} Mode
    </Button>
  );
};

export default ThemeToggle; 