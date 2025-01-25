import React from 'react';
import { motion } from 'framer-motion';
import { FaGithub, FaExternalLinkAlt } from 'react-icons/fa';
import './styles/ProjectCard.css';

const ProjectCard = ({ project, featured }) => {
  return (
    <motion.div
      className={`project-card ${featured ? 'featured' : ''}`}
      initial={{ opacity: 0, y: 20 }}
      animate={{ opacity: 1, y: 0 }}
      transition={{ duration: 0.5 }}
    >
      <div className="project-image">
        <img src={project.image} alt={project.title} />
        <div className="project-status">{project.status}</div>
      </div>
      
      <div className="project-content">
        <h3>{project.title}</h3>
        <p className="project-description">{project.description}</p>
        
        <div className="project-team">
          <span className="label">Team:</span> {project.team}
        </div>
        
        <div className="project-hackathon">
          <span className="label">Hackathon:</span> {project.hackathon}
        </div>

        <div className="project-technologies">
          <h4>Technologies:</h4>
          <ul>
            {project.technologies.map((tech) => (
              <li key={tech.id}>{tech.name}</li>
            ))}
          </ul>
        </div>

        {featured && project.features && (
          <div className="project-features">
            <h4>Features:</h4>
            <ul>
              {project.features.map((feature) => (
                <li key={feature.id}>{feature.description}</li>
              ))}
            </ul>
          </div>
        )}

        <div className="project-links">
          <a href={project.demoLink} target="_blank" rel="noopener noreferrer" className="demo-link">
            <FaExternalLinkAlt /> Demo
          </a>
          <a href={project.githubLink} target="_blank" rel="noopener noreferrer" className="github-link">
            <FaGithub /> Code
          </a>
        </div>
      </div>
    </motion.div>
  );
};

export default ProjectCard; 