import React from 'react';
import './styles/LoadingSpinner.css';

const LoadingSpinner = ({ size = 'md', className = '' }) => {
  const spinnerClass = `loading-spinner spinner-${size} ${className}`;
  
  return (
    <div className="spinner-container">
      <div className={spinnerClass}>
        <div></div>
        <div></div>
        <div></div>
        <div></div>
      </div>
    </div>
  );
};

export default LoadingSpinner; 