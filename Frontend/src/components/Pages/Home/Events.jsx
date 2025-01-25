import React from 'react';
import { motion } from 'framer-motion';
import { Link } from 'react-router-dom';
import { eventService } from '../../../services/api/eventService';
import { useEffect, useState } from 'react';
import LoadingSpinner from '../../UI/LoadingSpinner';
import { format } from 'date-fns';
import './styles/HomeEvents.css';

const HomeEvents = () => {
  const [events, setEvents] = useState([]);
  const [isLoading, setIsLoading] = useState(true);

  useEffect(() => {
    const fetchEvents = async () => {
      try {
        setIsLoading(true);
        const data = await eventService.getUpcomingEvents();
        console.log(data);
        setEvents(data.slice(0, 3)); // Show only first 3 upcoming events
      } catch (error) {
        console.error('Error fetching events:', error);
      } finally {
        setIsLoading(false);
      }
    };

    fetchEvents();
  }, []);

  if (isLoading) {
    return <LoadingSpinner />;
  }

  return (
    <section className="home-events-section">
      <div className="container">
        <motion.div
          initial={{ opacity: 0, y: 20 }}
          animate={{ opacity: 1, y: 0 }}
          transition={{ duration: 0.5 }}
          className="section-header"
        >
          <h2>Upcoming Events</h2>
          <p>Join our exciting hackathons and tech events</p>
        </motion.div>

        <div className="events-showcase">
          {events.map((event, index) => (
            <Link 
              to={`/events/${event.slug}`} 
              key={event.id}
            >
              <motion.div
                className="event-showcase-item"
                initial={{ opacity: 0, y: 20 }}
                animate={{ opacity: 1, y: 0 }}
                transition={{ delay: index * 0.2 }}
                whileHover={{ scale: 1.02 }}
              >
                <div className="event-image-wrapper">
                  <img src={event.image} alt={event.title} />
                  <div className="event-overlay">
                    <div className="event-date-badge">
                      {format(new Date(event.startDate), 'MMM dd, yyyy')}
                    </div>
                    <div className="event-content-overlay">
                      <h3>{event.title}</h3>
                      <p>{event.description}</p>
                      <span className="event-cta">
                        Register Now <span className="arrow">→</span>
                      </span>
                    </div>
                  </div>
                </div>
              </motion.div>
            </Link>
          ))}
        </div>

        <motion.div
          className="view-all-events"
          initial={{ opacity: 0 }}
          animate={{ opacity: 1 }}
          transition={{ delay: 0.6 }}
        >
          <Link to="/events" className="view-all-button">
            View All Events
            <motion.span
              className="arrow"
              animate={{ x: [0, 5, 0] }}
              transition={{ duration: 1.5, repeat: Infinity }}
            >
              →
            </motion.span>
          </Link>
        </motion.div>
      </div>
    </section>
  );
};

export default HomeEvents; 