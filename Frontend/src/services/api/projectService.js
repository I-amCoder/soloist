import api from '../../utils/api';
import { 
  GET_ALL_PROJECTS, 
  GET_FEATURED_PROJECTS, 
  GET_PROJECT_BY_ID, 
  GET_PROJECTS_BY_HACKATHON, 
  GET_PROJECTS_BY_STATUS, 
  GET_PROJECTS_BY_TECHNOLOGY, 
  GET_RECENT_PROJECTS 
} from '../../constants/apiRoutes';

// Simulate API delay like other services
const delay = (ms) => new Promise(resolve => setTimeout(resolve, ms));

export const projectService = {
  // Get all projects
  async getAllProjects() {
    try {
      const response = await api.get(GET_ALL_PROJECTS);
      return response.data;
    } catch (error) {
      console.error('Error fetching all projects:', error);
      throw error;
    }
  },

  // Get featured projects
  async getFeaturedProjects() {
    try {
      const response = await api.get(GET_FEATURED_PROJECTS);
      return response.data;
    } catch (error) {
      console.error('Error fetching featured projects:', error);
      throw error;
    }
  },

  // Get recent projects
  async getRecentProjects() {
    try {
      const response = await api.get(GET_RECENT_PROJECTS);
      return response.data;
    } catch (error) {
      console.error('Error fetching recent projects:', error);
      throw error;
    }
  },

  // Get project by ID
  async getProjectById(id) {
    try {
      const response = await api.get(GET_PROJECT_BY_ID(id));
      return response.data;
    } catch (error) {
      console.error('Error fetching project:', error);
      throw error;
    }
  },

  // Get projects by technology
  async getProjectsByTechnology(technology) {
    try {
      const response = await api.get(GET_PROJECTS_BY_TECHNOLOGY(technology));
      return response.data;
    } catch (error) {
      console.error('Error fetching projects by technology:', error);
      throw error;
    }
  },

  // Get projects by hackathon
  async getProjectsByHackathon(hackathon) {
    try {
      const response = await api.get(GET_PROJECTS_BY_HACKATHON(hackathon));
      return response.data;
    } catch (error) {
      console.error('Error fetching projects by hackathon:', error);
      throw error;
    }
  },

  // Get projects by status
  async getProjectsByStatus(status) {
    try {
      const response = await api.get(GET_PROJECTS_BY_STATUS(status));
      return response.data;
    } catch (error) {
      console.error('Error fetching projects by status:', error);
      throw error;
    }
  }
}; 