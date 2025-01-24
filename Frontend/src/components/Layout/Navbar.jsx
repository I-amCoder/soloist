import React, { useState, useEffect } from 'react';
import { Link, useLocation } from 'react-router-dom';
import { motion } from 'framer-motion';
import { useTheme } from '../../context/ThemeContext';
import ThemeToggle from '../ThemeToggle';
import { NAV_ITEMS } from '../../data/navigation';

const Navbar = () => {
  const { theme } = useTheme();
  const location = useLocation();
  const [scrolled, setScrolled] = useState(false);

  // Handle navbar background on scroll
  useEffect(() => {
    const handleScroll = () => {
      setScrolled(window.scrollY > 50);
    };
    window.addEventListener('scroll', handleScroll);
    return () => window.removeEventListener('scroll', handleScroll);
  }, []);

  return (
    <motion.nav
      initial={{ y: -100 }}
      animate={{ y: 0 }}
      className={`
        navbar navbar-expand-lg fixed-top
        ${scrolled ? 'navbar-scrolled' : ''}
        ${theme === 'dark' ? 'navbar-dark' : 'navbar-light'}
      `}
      style={{
        background: theme === 'dark' 
          ? scrolled ? 'rgba(33, 37, 41, 0.95)' : 'transparent'
          : scrolled ? 'rgba(255, 255, 255, 0.95)' : 'transparent',
        backdropFilter: scrolled ? 'blur(10px)' : 'none',
        transition: 'all 0.3s ease-in-out',
        height: scrolled ? '80px' : '90px',
        padding: scrolled ? '0' : '0'
      }}
    >
      <div className="container">
        <Link className="navbar-brand" to="/">
          <motion.div
            whileHover={{ scale: 1.05 }}
            className="d-flex align-items-center gap-2"
          >
            <span className="fw-bold text-gradient">ACM</span>
          </motion.div>
        </Link>

        <button 
          className="navbar-toggler border-0" 
          type="button" 
          data-bs-toggle="collapse" 
          data-bs-target="#navbarNav"
        >
          <span className="navbar-toggler-icon"></span> 
        </button>

        <div className="collapse navbar-collapse" id="navbarNav">
          <ul className="navbar-nav mx-auto">
            {NAV_ITEMS.filter(item => item.path !== '/').map((item) => (
              <motion.li 
                key={item.path} 
                className="nav-item"
                whileHover={{ scale: 1.05 }}
              >
                <Link 
                  className={`nav-link px-3 ${location.pathname === item.path ? 'active' : ''}`}
                  to={item.path}
                >
                  {item.label}
                </Link>
              </motion.li>
            ))}
          </ul>
          
          <div className="d-flex align-items-center gap-3">
            <ThemeToggle />
            <motion.div whileHover={{ scale: 1.05 }}>
              <Link to="/login" className="btn btn-primary btn-sm">
                Sign In
              </Link>
            </motion.div>
          </div>
        </div>
      </div>
    </motion.nav>
  );
};

export default Navbar; 