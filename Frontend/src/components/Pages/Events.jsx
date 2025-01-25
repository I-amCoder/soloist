import React, { useState, useEffect } from 'react';
import { motion } from 'framer-motion';
import EventCard from './Events/EventCard';
import LoadingSpinner from '../common/LoadingSpinner';
import { eventService } from '../../services/api/eventService';
import './styles/Events.css';

const Events = () => {
  const [events, setEvents] = useState({ upcoming: [], past: [] });
  const [isLoading, setIsLoading] = useState(true);

  useEffect(() => {
    const fetchEvents = async () => {
      try {
        setIsLoading(true);
        const data = await eventService.getAllEvents();
        setEvents(data);
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
    <div className="events-page">
      <motion.div
        className="events-header"
        initial={{ opacity: 0, y: -20 }}
        animate={{ opacity: 1, y: 0 }}
        transition={{ duration: 0.5 }}
      >
        <div className="container">
          <h1>ACM Events & Hackathons</h1>
          <p>Join our community of innovators and participate in exciting tech events</p>
        </div>
      </motion.div>

      <div className="events-content">
        {events.upcoming.length > 0 && (
          <section className="events-section">
            <h2>Upcoming Events</h2>
            <div className="events-grid">
              {events.upcoming.slice(0, 4).map((event, index) => (
                <EventCard 
                  key={event.id} 
                  event={event} 
                  index={index}
                  type="upcoming"
                />
              ))}
            </div>
          </section>
        )}

        {events.past.length > 0 && (
          <section className="events-section">
            <h2>Past Events</h2>
            <div className="events-grid">
              {events.past.slice(0, 4).map((event, index) => (
                <EventCard 
                  key={event.id} 
                  event={event} 
                  index={index}
                  type="past"
                />
              ))}
            </div>
          </section>
        )}
      </div>
    </div>
  );
};

export default Events; 