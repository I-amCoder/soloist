import React from 'react';
import ExecutiveMembers from './Home/ExecutiveMembers';
import { motion } from 'framer-motion';
import './styles/Team.css';

const Team = () => {
  return (
    <div className="team-page">
      <motion.div
        className="team-header"
        initial={{ opacity: 0, y: -20 }}
        animate={{ opacity: 1, y: 0 }}
        transition={{ duration: 0.5 }}
      >
        <div className="container">
          <h1>ACM Executive Council</h1>
          <p>Meet the dedicated leaders driving our ACM Student Chapter forward</p>
        </div>
      </motion.div>
      <ExecutiveMembers />
    </div>
  );
};

export default Team; 