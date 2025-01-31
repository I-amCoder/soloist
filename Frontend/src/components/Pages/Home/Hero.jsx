import React from 'react';
import { motion } from 'framer-motion';
import { Parallax } from 'react-parallax';
import { useNavigate } from 'react-router-dom';
import { useTheme } from '../../../context/ThemeContext';
import { HOME_DATA } from '../../../data/sections/home';
import { IMAGES } from '../../../data/images';
import Button from '../../UI/Button';

const Hero = () => {
  const { theme } = useTheme();
  const { hero } = HOME_DATA;
  const navigate = useNavigate();
  
  const handleExploreEvents = () => {
    navigate('/events');
  };

  const handleViewProjects = () => {
    navigate('/projects');
  };
  
  return (
    <Parallax
      blur={0}
      bgImage={IMAGES.hero.background}
      bgImageAlt="Digital network background"
      strength={200}
    >
      <div className="hero-container position-relative overflow-hidden">
        {/* Overlay */}
        <div 
          className={`overlay ${theme === 'dark' ? 'bg-dark' : 'bg-light'}`}
          style={{
            position: 'absolute',
            top: 0,
            left: 0,
            right: 0,
            bottom: 0,
            opacity: theme === 'dark' ? 0.8 : 0.9,
            zIndex: 1
          }}
        />

        {/* Content */}
        <div className="container position-relative min-vh-100 d-flex align-items-center" style={{ zIndex: 2 }}>
          <div className="row align-items-center">
            <div className="col-lg-6">
              <motion.div
                initial={{ opacity: 0, y: 20 }}
                animate={{ opacity: 1, y: 0 }}
                transition={{ duration: 0.8 }}
              >
                <h1 className="display-3 fw-bold mb-4 text-gradient">
                  {hero.title}
                </h1>
                <p className="lead mb-4">
                  {hero.subtitle}
                </p>
                <motion.div 
                  className="d-flex gap-3"
                  initial={{ opacity: 0 }}
                  animate={{ opacity: 1 }}
                  transition={{ delay: 0.5 }}
                >
                  <Button 
                    variant="primary" 
                    size="lg"
                    onClick={handleExploreEvents}
                  >
                    {hero.cta.primary.text}
                  </Button>
                  <Button 
                    variant="outline-secondary" 
                    size="lg"
                    onClick={handleViewProjects}
                  >
                    {hero.cta.secondary.text}
                  </Button>
                </motion.div>
              </motion.div>
            </div>
            
            <div className="col-lg-6">
              <motion.div
                initial={{ opacity: 0, scale: 0.8 }}
                animate={{ opacity: 1, scale: 1 }}
                transition={{ duration: 0.8 }}
                className="position-relative"
              >
                {/* Floating elements */}
                <div className="floating-elements">
                  {[...Array(3)].map((_, index) => (
                    <motion.div
                      key={index}
                      className="floating-circle"
                      animate={{
                        y: [0, -20, 0],
                        rotate: [0, 360]
                      }}
                      transition={{
                        duration: 3,
                        repeat: Infinity,
                        delay: index * 0.4,
                        ease: "easeInOut"
                      }}
                      style={{
                        position: 'absolute',
                        width: `${40 + index * 20}px`,
                        height: `${40 + index * 20}px`,
                        borderRadius: '50%',
                        background: `rgba(var(--bs-primary-rgb), ${0.3 - index * 0.1})`,
                        top: `${index * 25}%`,
                        right: `${index * 15}%`
                      }}
                    />
                  ))}
                </div>
              </motion.div>
            </div>
          </div>
        </div>
      </div>
    </Parallax>
  );
};

export default Hero; 