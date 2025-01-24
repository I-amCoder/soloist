import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import Login from './components/Auth/Login';
import Register from './components/Auth/Register';
import ThemeToggle from './components/ThemeToggle';
import { LOGIN_ROUTE, REGISTER_ROUTE } from './constants/routes';
import { useTheme } from './context/ThemeContext';

function App() {
  const { theme } = useTheme();

  return (
    <Router>
      <div className={`App ${theme === 'dark' ? 'bg-dark text-white' : 'bg-light text-dark'}`}>
        <ThemeToggle />
        <Routes>
          <Route path={LOGIN_ROUTE} element={<Login />} />
          <Route path={REGISTER_ROUTE} element={<Register />} />
        </Routes>
      </div>
    </Router>
  );
}

export default App; 