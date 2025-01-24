import React, { useEffect } from 'react';
import { useTheme } from '../../context/ThemeContext';
import './styles/buttons.css';

const Button = ({ 
  variant = 'primary', // primary, secondary, outline
  size = 'md',         // sm, md, lg
  loading = false,
  children,
  className = '',
  ...props 
}) => {
  const { theme } = useTheme();

  useEffect(() => {
    const handleMouseMove = (e) => {
      const buttons = document.querySelectorAll('.btn');
      buttons.forEach(button => {
        const rect = button.getBoundingClientRect();
        const x = ((e.clientX - rect.left) / button.clientWidth) * 100;
        const y = ((e.clientY - rect.top) / button.clientHeight) * 100;
        
        button.style.setProperty('--x', `${x}%`);
        button.style.setProperty('--y', `${y}%`);
      });
    };

    document.addEventListener('mousemove', handleMouseMove);
    return () => document.removeEventListener('mousemove', handleMouseMove);
  }, []);

  const getButtonClass = () => {
    const classes = ['btn', `btn-${variant}`];
    if (size) classes.push(`btn-${size}`);
    if (loading) classes.push('btn-loading');
    if (className) classes.push(className);
    return classes.join(' ');
  };

  return (
    <button 
      className={getButtonClass()}
      disabled={loading || props.disabled}
      {...props}
    >
      {children}
    </button>
  );
};

export default Button; 