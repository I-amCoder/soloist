import React from 'react';
import { Link } from 'react-router-dom';
import { useTheme } from '../../context/ThemeContext';

const Home = () => {
  const { theme } = useTheme();
  
  return (
    <div className="container py-5">
      <div className="row align-items-center">
        <div className="col-lg-6">
          <h1 className="display-4 fw-bold mb-4">Welcome to ACM Chapter</h1>
          <p className="lead mb-4">
            Exploring the frontiers of computing and technology through innovation,
            education, and collaboration.
          </p>
          <div className="d-flex gap-3">
            <Link to="/events" className={`btn ${theme === 'dark' ? 'btn-light' : 'btn-dark'}`}>
              Explore Events
            </Link>
            <Link to="/projects" className="btn btn-outline-primary">
              View Projects
            </Link>
          </div>
        </div>
        <div className="col-lg-6">
          {/* Placeholder for hero image */}
          <div className={`p-5 text-center ${theme === 'dark' ? 'bg-dark' : 'bg-light'}`}>
            <h3>Hero Image Placeholder</h3>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Home; 