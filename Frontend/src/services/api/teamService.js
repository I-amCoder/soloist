import api from '../../utils/api';
import { GET_ALL_EXECUTIVES, GET_EXECUTIVE_BY_ID, GET_EXECUTIVES_BY_ROLE } from '../../constants/apiRoutes';

// Simulate API delay
const delay = (ms) => new Promise(resolve => setTimeout(resolve, ms));

export const teamService = {
  // Get all executive members
  async getAllExecutives() {
    try {
      const response = await api.get(GET_ALL_EXECUTIVES);
      return response.data;
    } catch (error) {
      console.error('Error fetching executives:', error);
      throw error;
    }
  },

  // Get executive by ID
  async getExecutiveById(id) {
    try {
      const response = await api.get(GET_EXECUTIVE_BY_ID(id));
      return response.data;
    } catch (error) {
      console.error('Error fetching executive:', error);
      throw error;
    }
  },

  // Get executives by role
  async getExecutivesByRole(role) {
    try {
      const response = await api.get(GET_EXECUTIVES_BY_ROLE(role));
      return response.data;
    } catch (error) {
      console.error('Error fetching executives by role:', error);
      throw error;
    }
  }
}; 