import React from 'react';
import { motion } from 'framer-motion';
import { Link } from 'react-router-dom';
import { format } from 'date-fns';
import './styles/EventCard.css';

const EventCard = ({ event, index, type }) => {
  const formattedDate = format(new Date(event.startDate), 'MMM dd, yyyy');

  return (
    <motion.div
      className="event-card"
      initial={{ opacity: 0, y: 20 }}
      animate={{ opacity: 1, y: 0 }}
      whileHover={{ scale: 1.05, boxShadow: "0 8px 30px rgba(0,0,0,0.12)" }}
      transition={{ delay: index * 0.1 }}
    >
      <div className="event-image">
        <img src={event.image} alt={event.title} />
        <div className="event-date">{formattedDate}</div>
      </div>
      <div className="event-content">
        <h3>{event.title}</h3>
        <p>{event.description}</p>
        {type === 'upcoming' ? (
          <Link to={event.registrationLink} className="event-button">
            Register Now
          </Link>
        ) : (
          <Link to={event.projectsLink} className="event-button secondary">
            View Projects
          </Link>
        )}
      </div>
    </motion.div>
  );
};

export default EventCard; 