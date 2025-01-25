import React, { useEffect, useState } from 'react';
import { motion } from 'framer-motion';
import ProjectCard from '../Projects/ProjectCard';
import { projectService } from '../../../services/api/projectService';
import './styles/HomeProjects.css';

const HomeProjects = () => {
  const [projects, setProjects] = useState([]);
  const [isLoading, setIsLoading] = useState(true);

  useEffect(() => {
    const fetchProjects = async () => {
      try {
        setIsLoading(true);
        const data = await projectService.getFeaturedProjects(); // Assume this function fetches featured projects
        setProjects(data.slice(0, 3)); // Display only the first 3 projects
      } catch (error) {
        console.error('Error fetching projects:', error);
      } finally {
        setIsLoading(false);
      }
    };

    fetchProjects();
  }, []);

  if (isLoading) {
    return <div>Loading...</div>;
  }

  return (
    <section className="home-projects-section">
      <div className="container">
        <motion.div
          initial={{ opacity: 0, y: 20 }}
          animate={{ opacity: 1, y: 0 }}
          transition={{ duration: 0.5 }}
          className="section-header"
        >
          <h2>Featured Projects</h2>
          <p>Explore some of our innovative projects</p>
        </motion.div>

        <div className="projects-showcase">
          {projects.map((project) => (
            <ProjectCard key={project.id} project={project} featured={true} />
          ))}
        </div>
      </div>
    </section>
  );
};

export default HomeProjects; 