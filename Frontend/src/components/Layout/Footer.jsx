import React from 'react';
import { Link } from 'react-router-dom';
import { motion } from 'framer-motion';
import { FaLinkedin, FaInstagram, FaFacebook } from 'react-icons/fa';
import './styles/Footer.css';

const Footer = () => {
  return (
    <footer className="footer">
      <div className="container">
        <div className="footer-content">
          <div className="footer-section">
            <h3>ACM Student Chapter</h3>
            <p>Advancing Computing as a Science & Profession</p>
            <div className="social-links">
              <motion.a
                href="https://linkedin.com/company/acm-student-chapter"
                target="_blank"
                rel="noopener noreferrer"
                whileHover={{ scale: 1.2, y: -5 }}
                whileTap={{ scale: 0.9 }}
                className="social-icon linkedin"
              >
                <FaLinkedin size={24} />
              </motion.a>
              <motion.a
                href="https://instagram.com/acm_student_chapter"
                target="_blank"
                rel="noopener noreferrer"
                whileHover={{ scale: 1.2, y: -5 }}
                whileTap={{ scale: 0.9 }}
                className="social-icon instagram"
              >
                <FaInstagram size={24} />
              </motion.a>
              <motion.a
                href="https://facebook.com/acmstudentchapter"
                target="_blank"
                rel="noopener noreferrer"
                whileHover={{ scale: 1.2, y: -5 }}
                whileTap={{ scale: 0.9 }}
                className="social-icon facebook"
              >
                <FaFacebook size={24} />
              </motion.a>
            </div>
          </div>
          <div className="col-md-6">
            <h5>ACM Chapter</h5>
            <p className="mb-0">Association for Computing Machinery</p>
          </div>
        </div>
        <div className="footer-bottom">
          <p>&copy; {new Date().getFullYear()} ACM Student Chapter. All rights reserved.</p>
        </div>
      </div>
    </footer>
  );
};

export default Footer; 