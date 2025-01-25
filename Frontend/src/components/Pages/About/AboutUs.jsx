import React from 'react';
import { motion } from 'framer-motion';
import { FaRocket, FaUsers, FaLightbulb } from 'react-icons/fa';
import './styles/AboutUs.css';

const AboutUs = () => {
  return (
    <div className="about-page">
      {/* Hero Section */}
      <motion.div 
        className="about-header"
        initial={{ opacity: 0, y: -20 }}
        animate={{ opacity: 1, y: 0 }}
        transition={{ duration: 0.5 }}
      >
        <div className="container">
          <h1>About ACM Student Chapter</h1>
          <p>Empowering students through technology and innovation</p>
        </div>
      </motion.div>

      {/* Main Content */}
      <div className="about-content container">
        {/* Mission Section */}
        <motion.section 
          className="about-section"
          initial={{ opacity: 0, y: 20 }}
          animate={{ opacity: 1, y: 0 }}
          transition={{ duration: 0.5, delay: 0.2 }}
        >
          <h2>Our Mission</h2>
          <p>
            The ACM Student Chapter is dedicated to fostering a dynamic community 
            of tech enthusiasts, promoting knowledge sharing, and creating opportunities 
            for students to grow in the field of computing.
          </p>
        </motion.section>

        {/* Core Values */}
        <motion.section 
          className="about-section values-grid"
          initial={{ opacity: 0, y: 20 }}
          animate={{ opacity: 1, y: 0 }}
          transition={{ duration: 0.5, delay: 0.3 }}
        >
          <div className="value-card">
            <FaRocket className="value-icon" />
            <h3>Innovation</h3>
            <p>Fostering creative solutions and cutting-edge technology exploration</p>
          </div>
          <div className="value-card">
            <FaUsers className="value-icon" />
            <h3>Community</h3>
            <p>Building a supportive network of tech enthusiasts and future leaders</p>
          </div>
          <div className="value-card">
            <FaLightbulb className="value-icon" />
            <h3>Learning</h3>
            <p>Promoting continuous learning and skill development</p>
          </div>
        </motion.section>
      </div>
    </div>
  );
};

export default AboutUs;
