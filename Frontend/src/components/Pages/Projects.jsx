import React, { useState, useEffect } from 'react';
import { motion } from 'framer-motion';
import ProjectCard from './Projects/ProjectCard';
import { projectService } from '../../services/api/projectService';
import './styles/Projects.css';

const Projects = () => {
  const [projects, setProjects] = useState({ featured: [], recent: [] });
  const [isLoading, setIsLoading] = useState(true);

  useEffect(() => {
    const fetchProjects = async () => {
      try {
        setIsLoading(true);
        const data = await projectService.getAllProjects();
        console.log(data);
        
        setProjects(data);
      } catch (error) {
        console.error('Error fetching projects:', error);
      } finally {
        setIsLoading(false);
      }
    };

    fetchProjects();
  }, []);

  if (isLoading) {
    return <div className="loading-spinner">Loading...</div>;
  }

  return (
    <div className="projects-page">
      <motion.div
        className="projects-header"
        initial={{ opacity: 0, y: -20 }}
        animate={{ opacity: 1, y: 0 }}
        transition={{ duration: 0.5 }}
      >
        <h1>Hackathon Projects</h1>
        <p>Discover innovative projects created during our hackathons</p>
      </motion.div>

      <div className="projects-content">
        <section className="featured-projects">
          <h2>Featured Projects</h2>
          <div className="projects-grid">
            {projects.map((project) => (
              <ProjectCard key={project.id} project={project} featured={true} />
            ))}
          </div>
        </section>

        <section className="recent-projects">
          <h2>Recent Projects</h2>
          <div className="projects-grid">
            {projects.map((project) => (
              <ProjectCard key={project.id} project={project} />
            ))}
          </div>
        </section>
      </div>
    </div>
  );
};

export default Projects; 