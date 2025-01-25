import React, { useState, useEffect } from 'react';
import { motion, AnimatePresence } from 'framer-motion';
import { useTheme } from '../../../context/ThemeContext';
import { teamService } from '../../../services/api/teamService';
import { FaLinkedin, FaGithub, FaTwitter } from 'react-icons/fa';
import LoadingSpinner from '../../UI/LoadingSpinner';
import './styles/ExecutiveMembers.css';

const ExecutiveMembers = () => {
  const { theme } = useTheme();
  const [currentIndex, setCurrentIndex] = useState(0);
  const [executives, setExecutives] = useState([]);
  const [isLoading, setIsLoading] = useState(true);
  const [error, setError] = useState(null);

  // Add auto-slide functionality
  useEffect(() => {
    const autoSlideTimer = setInterval(() => {
      setCurrentIndex((prev) => (prev + 1) % executives.length);
    }, 5000); // Change slide every 5 seconds

    // Cleanup timer on component unmount
    return () => clearInterval(autoSlideTimer);
  }, [executives.length]);

  // Pause auto-slide on hover
  const [isHovered, setIsHovered] = useState(false);

  useEffect(() => {
    if (!isHovered && executives.length > 0) {
      const timer = setInterval(() => {
        setCurrentIndex((prev) => (prev + 1) % executives.length);
      }, 5000);
      return () => clearInterval(timer);
    }
  }, [isHovered, executives.length]);

  useEffect(() => {
    const fetchExecutives = async () => {
      try {
        setIsLoading(true);
        const data = await teamService.getAllExecutives();
        console.log(data);
        
        setExecutives(data);
        setError(null);
      } catch (err) {
        setError('Failed to load team members. Please try again later.');
        console.error('Error fetching executives:', err);
      } finally {
        setIsLoading(false);
      }
    };

    fetchExecutives();
  }, []);

  const handleNext = () => {
    setCurrentIndex((prev) => (prev + 1) % executives.length);
  };

  const handlePrev = () => {
    setCurrentIndex((prev) => (prev - 1 + executives.length) % executives.length);
  };

  if (isLoading) {
    return (
      <div className="executive-section loading">
        <LoadingSpinner />
      </div>
    );
  }

  if (error) {
    return (
      <div className="executive-section error">
        <div className="error-message">
          {error}
        </div>
      </div>
    );
  }

  if (!executives.length) {
    return null;
  }

  const currentExecutive = executives[currentIndex];

  return (
    <section className={`executive-section ${theme}`}>
      <div className="container py-5">
        <motion.h2 
          className="text-center mb-5"
          initial={{ opacity: 0, y: 20 }}
          whileInView={{ opacity: 1, y: 0 }}
          transition={{ duration: 0.5 }}
        >
          Meet Our Executive Team
        </motion.h2>

        <div 
          className="carousel-container"
          onMouseEnter={() => setIsHovered(true)}
          onMouseLeave={() => setIsHovered(false)}
        >
          <button 
            className="carousel-arrow prev"
            onClick={handlePrev}
            aria-label="Previous member"
          >
            ‹
          </button>

          <AnimatePresence mode="wait">
            <motion.div 
              key={currentIndex}
              className="executive-card"
              initial={{ opacity: 0, x: 100 }}
              animate={{ opacity: 1, x: 0 }}
              exit={{ opacity: 0, x: -100 }}
              transition={{ duration: 0.3 }}
            >
              <div className="executive-image">
                <img 
                  src={currentExecutive.image} 
                  alt={currentExecutive.name}
                />
              </div>
              <div className="executive-info">
                <h3>{currentExecutive.name}</h3>
                <h4>{currentExecutive.role}</h4>
                <p className="department">{currentExecutive.department} • {currentExecutive.year}</p>
                <p className="description">{currentExecutive.description}</p>
                <div className="social-links">
                  {currentExecutive.socialLinks.linkedin && (
                    <a 
                      href={currentExecutive.socialLinks.linkedin} 
                      target="_blank" 
                      rel="noopener noreferrer"
                      aria-label="LinkedIn Profile"
                    >
                      <FaLinkedin />
                    </a>
                  )}
                  {currentExecutive.socialLinks.github && (
                    <a 
                      href={currentExecutive.socialLinks.github} 
                      target="_blank" 
                      rel="noopener noreferrer"
                      aria-label="GitHub Profile"
                    >
                      <FaGithub />
                    </a>
                  )}
                  {currentExecutive.socialLinks.twitter && (
                    <a 
                      href={currentExecutive.socialLinks.twitter} 
                      target="_blank" 
                      rel="noopener noreferrer"
                      aria-label="Twitter Profile"
                    >
                      <FaTwitter />
                    </a>
                  )}
                </div>
              </div>
            </motion.div>
          </AnimatePresence>

          <button 
            className="carousel-arrow next"
            onClick={handleNext}
            aria-label="Next member"
          >
            ›
          </button>
        </div>

        <div className="carousel-indicators">
          {executives.map((_, index) => (
            <button
              key={index}
              className={`indicator ${index === currentIndex ? 'active' : ''}`}
              onClick={() => setCurrentIndex(index)}
              aria-label={`Go to slide ${index + 1}`}
            />
          ))}
        </div>
      </div>
    </section>
  );
};

export default ExecutiveMembers; 