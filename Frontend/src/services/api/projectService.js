import projectsData from '../../data/mock/projects.json';

// Simulate API delay like other services
const delay = (ms) => new Promise(resolve => setTimeout(resolve, ms));

export const projectService = {
  // Get all projects
  async getAllProjects() {
    await delay(800);
    return {
      featured: projectsData.featured,
      recent: projectsData.recent
    };
  },

  // Get featured projects
  async getFeaturedProjects() {
    await delay(600);
    return projectsData.featured;
  },

  // Get recent projects
  async getRecentProjects() {
    await delay(600);
    return projectsData.recent;
  },

  // Get project by ID
  async getProjectById(id) {
    await delay(500);
    const allProjects = [...projectsData.featured, ...projectsData.recent];
    const project = allProjects.find(project => project.id === id);
    
    if (!project) {
      throw new Error('Project not found');
    }
    
    return project;
  },

  // Get projects by technology
  async getProjectsByTechnology(technology) {
    await delay(700);
    const allProjects = [...projectsData.featured, ...projectsData.recent];
    return allProjects.filter(project => 
      project.technologies.some(tech => 
        tech.toLowerCase().includes(technology.toLowerCase())
      )
    );
  },

  // Get projects by hackathon
  async getProjectsByHackathon(hackathonName) {
    await delay(700);
    const allProjects = [...projectsData.featured, ...projectsData.recent];
    return allProjects.filter(project => 
      project.hackathon.toLowerCase().includes(hackathonName.toLowerCase())
    );
  },

  // Get projects by status
  async getProjectsByStatus(status) {
    await delay(600);
    const allProjects = [...projectsData.featured, ...projectsData.recent];
    return allProjects.filter(project => 
      project.status.toLowerCase() === status.toLowerCase()
    );
  }
}; 