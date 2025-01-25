import React, { useEffect, useState } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { motion } from 'framer-motion';
import { format } from 'date-fns';
import { eventService } from '../../../services/api/eventService';
import LoadingSpinner from '../../UI/LoadingSpinner';
import './styles/EventDetail.css';

const EventDetail = () => {
  const { slug } = useParams();
  const navigate = useNavigate();
  const [event, setEvent] = useState(null);
  const [isLoading, setIsLoading] = useState(true);
  const [selectedImage, setSelectedImage] = useState(null);

  useEffect(() => {
    const fetchEventDetails = async () => {
      try {
        setIsLoading(true);
        const eventData = await eventService.getEventBySlug(slug);
        setEvent(eventData);
      } catch (error) {
        console.error('Error fetching event details:', error);
        navigate('/404');
      } finally {
        setIsLoading(false);
      }
    };

    fetchEventDetails();
  }, [slug, navigate]);

  if (isLoading) return <LoadingSpinner />;
  if (!event) return null;

  const isPastEvent = new Date(event.startDate) < new Date();

  const renderUpcomingEvent = () => (
    <>
      <motion.section
        className="event-section"
        initial={{ opacity: 0, y: 20 }}
        animate={{ opacity: 1, y: 0 }}
        transition={{ delay: 0.3 }}
      >
        <h2>Schedule</h2>
        <div className="schedule-grid">
          {event.schedule?.map((day, index) => (
            <div key={index} className="schedule-day">
              <h3>{day.day}</h3>
              {day.events.map((item, i) => (
                <div key={i} className="schedule-item">
                  <span className="time">{item.time}</span>
                  <span className="activity">{item.activity}</span>
                </div>
              ))}
            </div>
          ))}
        </div>
      </motion.section>

      {event.prizes && (
        <motion.section
          className="event-section"
          initial={{ opacity: 0, y: 20 }}
          animate={{ opacity: 1, y: 0 }}
          transition={{ delay: 0.4 }}
        >
          <h2>Prizes</h2>
          <div className="prizes-grid">
            {event.prizes.map((prize, index) => (
              <div key={index} className="prize-card">
                <h3>{prize.place}</h3>
                <div className="prize-amount">{prize.reward}</div>
                <ul>
                  {prize.benefits.map((benefit, i) => (
                    <li key={i}>{benefit}</li>
                  ))}
                </ul>
              </div>
            ))}
          </div>
        </motion.section>
      )}

      {event.rules && (
        <motion.section
          className="event-section"
          initial={{ opacity: 0, y: 20 }}
          animate={{ opacity: 1, y: 0 }}
          transition={{ delay: 0.5 }}
        >
          <h2>Rules</h2>
          <ul className="rules-list">
            {event.rules.map((rule, index) => (
              <li key={index}>{rule}</li>
            ))}
          </ul>
        </motion.section>
      )}

      {event.venue && (
        <motion.section
          className="event-section"
          initial={{ opacity: 0, y: 20 }}
          animate={{ opacity: 1, y: 0 }}
          transition={{ delay: 0.6 }}
        >
          <h2>Venue</h2>
          <div className="venue-info">
            <h3>{event.venue.name}</h3>
            <p>{event.venue.address}</p>
            <a 
              href={event.venue.mapLink} 
              target="_blank" 
              rel="noopener noreferrer"
              className="map-link"
            >
              View on Map
            </a>
          </div>
        </motion.section>
      )}

      <motion.section
        className="event-section"
        initial={{ opacity: 0, y: 20 }}
        animate={{ opacity: 1, y: 0 }}
        transition={{ delay: 0.7 }}
      >
        <h2>Sponsors</h2>
        <div className="sponsors-grid">
          {event.sponsors?.map((sponsor, index) => (
            <a
              key={index}
              href={sponsor.website}
              target="_blank"
              rel="noopener noreferrer"
              className="sponsor-card"
            >
              <img src={sponsor.logo} alt={sponsor.name} />
              <h3>{sponsor.name}</h3>
            </a>
          ))}
        </div>
      </motion.section>
    </>
  );

  const renderPastEvent = () => (
    <>
      {event.results?.winners && (
        <motion.section
          className="event-section"
          initial={{ opacity: 0, y: 20 }}
          animate={{ opacity: 1, y: 0 }}
          transition={{ delay: 0.3 }}
        >
          <h2>Results</h2>
          <div className="winners-grid">
            {event.results.winners.map((winner, index) => (
              <div key={index} className="winner-card">
                <h3>{winner.place}</h3>
                <h4>{winner.team}</h4>
                <p className="project-name">{winner.project}</p>
                <p className="project-description">{winner.description}</p>
              </div>
            ))}
          </div>
        </motion.section>
      )}

      {event.gallery && (
        <motion.section
          className="event-section"
          initial={{ opacity: 0, y: 20 }}
          animate={{ opacity: 1, y: 0 }}
          transition={{ delay: 0.4 }}
        >
          <h2>Event Gallery</h2>
          <div className="gallery-grid">
            {event.gallery.map((item, index) => (
              <div 
                key={index} 
                className="gallery-item"
                onClick={() => setSelectedImage(item)}
                style={{ cursor: 'pointer' }}
              >
                <img src={item.url} alt={item.caption} />
                <p>{item.caption}</p>
              </div>
            ))}
          </div>
        </motion.section>
      )}

      {selectedImage && (
        <div className="image-modal">
          <div className="modal-overlay" onClick={() => setSelectedImage(null)} />
          <div className="modal-container">
            <button 
              className="close-button"
              onClick={() => setSelectedImage(null)}
            >
              ×
            </button>
            <div className="modal-content">
              <img src={selectedImage.url} alt={selectedImage.caption} />
              {selectedImage.caption && (
                <p className="modal-caption">{selectedImage.caption}</p>
              )}
            </div>
          </div>
        </div>
      )}
    </>
  );

  return (
    <div className="event-detail-page">
      <motion.div 
        className="event-hero"
        initial={{ opacity: 0 }}
        animate={{ opacity: 1 }}
        transition={{ duration: 0.5 }}
      >
        <div className="event-hero-content">
          <motion.div
            initial={{ opacity: 0, y: 20 }}
            animate={{ opacity: 1, y: 0 }}
            transition={{ delay: 0.2 }}
          >
            <div className="event-date">
              {format(new Date(event.startDate), 'MMMM dd, yyyy')}
            </div>
            <h1>{event.title}</h1>
            <p>{event.fullDescription}</p>
            {!isPastEvent && event.registrationLink && (
              <motion.button
                className="register-button"
                whileHover={{ scale: 1.05 }}
                whileTap={{ scale: 0.95 }}
                onClick={() => window.location.href = event.registrationLink}
              >
                Register Now
              </motion.button>
            )}
          </motion.div>
        </div>
        <div className="event-hero-image">
          <img src={event.image} alt={event.title} />
        </div>
      </motion.div>

      <div className="event-content">
        {isPastEvent ? renderPastEvent() : renderUpcomingEvent()}
      </div>
    </div>
  );
};

export default EventDetail;