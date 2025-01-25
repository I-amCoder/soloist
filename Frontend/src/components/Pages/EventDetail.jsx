import React, { useEffect, useState } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { motion } from 'framer-motion';
import { format } from 'date-fns';
import { FaMapMarkerAlt, FaCalendarAlt, FaTrophy, FaClock, FaUsers, FaGlobe, FaChartBar } from 'react-icons/fa';
import { BiLinkExternal } from 'react-icons/bi';

// ... existing imports and initial component code ...

  const renderUpcomingEvent = () => (
    <>
      <motion.section
        className="event-section"
        initial={{ opacity: 0, y: 20 }}
        animate={{ opacity: 1, y: 0 }}
        transition={{ delay: 0.3 }}
      >
        <h2><FaCalendarAlt className="section-icon" /> Schedule</h2>
        {/* ... existing schedule code ... */}
      </motion.section>

      {event.sponsors && (
        <motion.section
          className="event-section"
          initial={{ opacity: 0, y: 20 }}
          animate={{ opacity: 1, y: 0 }}
          transition={{ delay: 0.35 }}
        >
          <h2>Our Sponsors</h2>
          <div className="sponsors-grid">
            {event.sponsors.map((sponsor, index) => (
              <a
                key={index}
                href={sponsor.website}
                target="_blank"
                rel="noopener noreferrer"
                className="sponsor-card"
              >
                <img src={sponsor.logo} alt={sponsor.name} />
                <span className="sponsor-name">
                  {sponsor.name} <BiLinkExternal className="external-link-icon" />
                </span>
              </a>
            ))}
          </div>
        </motion.section>
      )}

      {/* ... existing prizes section with updated icon ... */}
      {event.prizes && (
        <motion.section
          className="event-section"
          initial={{ opacity: 0, y: 20 }}
          animate={{ opacity: 1, y: 0 }}
          transition={{ delay: 0.4 }}
        >
          <h2><FaTrophy className="section-icon" /> Prizes</h2>
          {/* ... existing prizes code ... */}
        </motion.section>
      )}

      {/* ... existing rules and venue sections ... */}
      {event.venue && (
        <motion.section
          className="event-section"
          initial={{ opacity: 0, y: 20 }}
          animate={{ opacity: 1, y: 0 }}
          transition={{ delay: 0.6 }}
        >
          <h2><FaMapMarkerAlt className="section-icon" /> Venue</h2>
          {/* ... existing venue code ... */}
        </motion.section>
      )}
    </>
  );

  const renderPastEvent = () => (
    <>
      {event.results?.statistics && (
        <motion.section
          className="event-section"
          initial={{ opacity: 0, y: 20 }}
          animate={{ opacity: 1, y: 0 }}
          transition={{ delay: 0.25 }}
        >
          <h2><FaChartBar className="section-icon" /> Event Statistics</h2>
          <div className="statistics-grid">
            <div className="stat-card">
              <FaUsers className="stat-icon" />
              <div className="stat-value">{event.results.statistics.participants}</div>
              <div className="stat-label">Participants</div>
            </div>
            <div className="stat-card">
              <FaClock className="stat-icon" />
              <div className="stat-value">{event.results.statistics.projects}</div>
              <div className="stat-label">Projects</div>
            </div>
            <div className="stat-card">
              <FaGlobe className="stat-icon" />
              <div className="stat-value">{event.results.statistics.countries}</div>
              <div className="stat-label">Countries</div>
            </div>
          </div>
        </motion.section>
      )}

      {event.highlights && (
        <motion.section
          className="event-section"
          initial={{ opacity: 0, y: 20 }}
          animate={{ opacity: 1, y: 0 }}
          transition={{ delay: 0.35 }}
        >
          <h2>Event Highlights</h2>
          <div className="highlights-grid">
            {event.highlights.map((highlight, index) => (
              <div key={index} className="highlight-card">
                <h3>{highlight.title}</h3>
                <div className="speaker">{highlight.speaker}</div>
                <p>{highlight.description}</p>
              </div>
            ))}
          </div>
        </motion.section>
      )}

      {/* ... existing winners and gallery sections ... */}
    </>
  );

  // ... rest of the existing code ...