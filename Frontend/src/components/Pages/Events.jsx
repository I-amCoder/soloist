import React, { useState, useEffect } from 'react';
import { motion, AnimatePresence } from 'framer-motion';
import EventCard from './EventCard';
import LoadingSpinner from '../../UI/LoadingSpinner';
import { eventService } from '../../../services/api/eventService';
import './styles/Events.css';

const Events = () => {
  const [events, setEvents] = useState({ upcoming: [], past: [] });
  const [isLoading, setIsLoading] = useState(true);
  const [error, setError] = useState(null);
  const [activeTab, setActiveTab] = useState('upcoming');

  useEffect(() => {
    const fetchEvents = async () => {
      try {
        setIsLoading(true);
        const data = await eventService.getAllEvents();
        setEvents(data);
      } catch (err) {
        setError('Failed to load events. Please try again later.');
        console.error('Error fetching events:', err);
      } finally {
        setIsLoading(false);
      }
    };

    fetchEvents();
  }, []);

  if (isLoading) {
    return (
      <div className="events-loading">
        <LoadingSpinner />
      </div>
    );
  }

  if (error) {
    return <div className="events-error">{error}</div>;
  }

  return (
    <div className="events-page">
      <motion.div
        className="events-header"
        initial={{ opacity: 0, y: -20 }}
        animate={{ opacity: 1, y: 0 }}
        transition={{ duration: 0.5 }}
      >
        <h1>Hackathon Events</h1>
        <p>Explore our exciting events and activities</p>
      </motion.div>

      <div className="events-content">
        <div className="events-tabs">
          <button
            className={`tab-button ${activeTab === 'upcoming' ? 'active' : ''}`}
            onClick={() => setActiveTab('upcoming')}
          >
            Upcoming Events
          </button>
          <button
            className={`tab-button ${activeTab === 'past' ? 'active' : ''}`}
            onClick={() => setActiveTab('past')}
          >
            Past Events
          </button>
        </div>

        <AnimatePresence mode="wait">
          <motion.div
            key={activeTab}
            initial={{ opacity: 0, x: 20 }}
            animate={{ opacity: 1, x: 0 }}
            exit={{ opacity: 0, x: -20 }}
            className="events-grid"
          >
            {events[activeTab].map((event, index) => (
              <EventCard
                key={event.id}
                event={event}
                index={index}
                type={activeTab}
              />
            ))}
          </motion.div>
        </AnimatePresence>
      </div>
    </div>
  );
};

export default Events; 