import React from 'react';
import { motion } from 'framer-motion';
import { Parallax } from 'react-parallax';
import { FaRocket, FaUsers, FaLightbulb, FaCode, FaGlobe, FaMedal, FaEnvelope, FaLinkedin, FaGithub } from 'react-icons/fa';
import './styles/AboutUs.css';

const AboutUs = () => {
  // Using a free background from SVGBackgrounds.com
  const bgImage = "data:image/svg+xml,%3Csvg xmlns='http://www.w3.org/2000/svg' width='100%25' height='100%25' viewBox='0 0 1600 800'%3E%3Cg %3E%3Cpath fill='%23003153' d='M486 705.8c-109.3-21.8-223.4-32.2-335.3-19.4C99.5 692.1 49 703 0 719.8V800h843.8c-115.9-33.2-230.8-68.1-347.6-92.2C492.8 707.1 489.4 706.5 486 705.8z'/%3E%3Cpath fill='%23004b80' d='M1600 0H0v719.8c49-16.8 99.5-27.8 150.7-33.5c111.9-12.7 226-2.4 335.3 19.4c3.4 0.7 6.8 1.4 10.2 2c116.8 24 231.7 59 347.6 92.2H1600V0z'/%3E%3Cpath fill='%230066ac' d='M478.4 581c3.2 0.8 6.4 1.7 9.5 2.5c196.2 52.5 388.7 133.5 593.5 176.6c174.2 36.6 349.5 29.2 518.6-10.2V0H0v574.9c52.3-17.6 106.5-27.7 161.1-30.9C268.4 537.4 375.7 554.2 478.4 581z'/%3E%3Cpath fill='%230082d9' d='M0 0v429.4c55.6-18.4 113.5-27.3 171.4-27.7c102.8-0.8 203.2 22.7 299.3 54.5c3 1 5.9 2 8.9 3c183.6 62 365.7 146.1 562.4 192.1c186.7 43.7 376.3 34.4 557.9-12.6V0H0z'/%3E%3Cpath fill='%23009FFF' d='M181.8 259.4c98.2 6 191.9 35.2 281.3 72.1c2.8 1.1 5.5 2.3 8.3 3.4c171 71.6 342.7 158.5 531.3 207.7c198.8 51.8 403.4 40.8 597.3-14.8V0H0v283.2C59 263.6 120.6 255.7 181.8 259.4z'/%3E%3C/g%3E%3C/svg%3E";

  const executiveMembers = [
    {
      name: "John Doe",
      role: "Chapter Chair",
      email: "chair@acmchapter.org",
      linkedin: "https://linkedin.com/in/johndoe",
      github: "https://github.com/johndoe"
    },
    {
      name: "Jane Smith",
      role: "Vice Chair",
      email: "vicechair@acmchapter.org",
      linkedin: "https://linkedin.com/in/janesmith",
      github: "https://github.com/janesmith"
    },
    {
      name: "Mike Johnson",
      role: "Secretary",
      email: "secretary@acmchapter.org",
      linkedin: "https://linkedin.com/in/mikejohnson",
      github: "https://github.com/mikejohnson"
    }
  ];

  return (
    <div className="about-page">
      <Parallax
        blur={0}
        bgImage={bgImage}
        bgImageAlt="Technology Background"
        strength={200}
        className="about-hero-parallax"
      >
        <motion.div 
          className="about-header"
          initial={{ opacity: 0, y: -20 }}
          animate={{ opacity: 1, y: 0 }}
          transition={{ duration: 0.5 }}
        >
          <div className="container">
            <motion.h1
              initial={{ opacity: 0, y: 30 }}
              animate={{ opacity: 1, y: 0 }}
              transition={{ duration: 0.8, delay: 0.2 }}
            >
              ACM Student Chapter
            </motion.h1>
            <motion.p
              initial={{ opacity: 0, y: 20 }}
              animate={{ opacity: 1, y: 0 }}
              transition={{ duration: 0.8, delay: 0.4 }}
            >
              Advancing Computing as a Science & Profession
            </motion.p>
          </div>
          
          {/* Floating Elements */}
          <div className="floating-elements">
            {[...Array(5)].map((_, index) => (
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
              />
            ))}
          </div>
        </motion.div>
      </Parallax>

      <div className="about-content container">
        <motion.section 
          className="about-section mission-section"
          initial={{ opacity: 0, y: 20 }}
          whileInView={{ opacity: 1, y: 0 }}
          viewport={{ once: true }}
          transition={{ duration: 0.5, delay: 0.2 }}
        >
          <h2>Our Mission</h2>
          <p>
            As the world's largest computing society, ACM strengthens the profession's collective voice through strong leadership, 
            promotion of the highest standards, and recognition of technical excellence. We support the professional growth of our 
            members by providing opportunities for life‐long learning, career development, and professional networking.
          </p>
        </motion.section>

        <div className="values-grid">
          {[
            {
              icon: <FaGlobe />,
              title: "Global Impact",
              description: "Connecting with 100,000+ ACM members worldwide"
            },
            {
              icon: <FaCode />,
              title: "Technical Excellence",
              description: "Fostering innovation and technical advancement"
            },
            {
              icon: <FaUsers />,
              title: "Community",
              description: "Building a vibrant tech community"
            },
            {
              icon: <FaMedal />,
              title: "Recognition",
              description: "Celebrating achievements in computing"
            },
            {
              icon: <FaLightbulb />,
              title: "Learning",
              description: "Continuous education and skill development"
            },
            {
              icon: <FaRocket />,
              title: "Innovation",
              description: "Pushing boundaries in technology"
            }
          ].map((value, index) => (
            <motion.div
              key={index}
              className="value-card"
              initial={{ opacity: 0, y: 30 }}
              whileInView={{ opacity: 1, y: 0 }}
              viewport={{ once: true }}
              transition={{ duration: 0.5, delay: index * 0.1 }}
              whileHover={{ 
                scale: 1.05,
                boxShadow: "0 8px 30px rgba(0,0,0,0.12)"
              }}
            >
              <div className="value-icon">{value.icon}</div>
              <h3>{value.title}</h3>
              <p>{value.description}</p>
            </motion.div>
          ))}
        </div>

        {/* New Achievements Section */}
        <motion.section 
          className="about-section achievements-section"
          initial={{ opacity: 0, y: 20 }}
          whileInView={{ opacity: 1, y: 0 }}
          viewport={{ once: true }}
          transition={{ duration: 0.5 }}
        >
          <h2>Our Achievements</h2>
          <div className="achievements-grid">
            <div className="achievement-card">
              <h3>500+</h3>
              <p>Active Members</p>
            </div>
            <div className="achievement-card">
              <h3>50+</h3>
              <p>Events Organized</p>
            </div>
            <div className="achievement-card">
              <h3>20+</h3>
              <p>Awards Won</p>
            </div>
          </div>
        </motion.section>

        {/* Contact Section */}
        <motion.section 
          className="about-section contact-section"
          initial={{ opacity: 0, y: 20 }}
          whileInView={{ opacity: 1, y: 0 }}
          viewport={{ once: true }}
          transition={{ duration: 0.5 }}
        >
          <h2>Executive Council</h2>
          <div className="contact-grid">
            {executiveMembers.map((member, index) => (
              <motion.div 
                key={index}
                className="contact-card"
                initial={{ opacity: 0, y: 20 }}
                whileInView={{ opacity: 1, y: 0 }}
                viewport={{ once: true }}
                transition={{ duration: 0.5, delay: index * 0.1 }}
                whileHover={{ scale: 1.05 }}
              >
                <h3>{member.name}</h3>
                <p className="role">{member.role}</p>
                <div className="contact-links">
                  <a 
                    href={`mailto:${member.email}`}
                    className="contact-icon"
                    aria-label="Email"
                  >
                    <FaEnvelope />
                  </a>
                  <a 
                    href={member.linkedin}
                    target="_blank"
                    rel="noopener noreferrer"
                    className="contact-icon"
                    aria-label="LinkedIn"
                  >
                    <FaLinkedin />
                  </a>
                  <a 
                    href={member.github}
                    target="_blank"
                    rel="noopener noreferrer"
                    className="contact-icon"
                    aria-label="GitHub"
                  >
                    <FaGithub />
                  </a>
                </div>
              </motion.div>
            ))}
          </div>
        </motion.section>
      </div>
    </div>
  );
};

export default AboutUs;
