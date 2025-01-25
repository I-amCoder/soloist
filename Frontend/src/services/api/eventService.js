import api from '../../utils/api';
import { GET_ALL_EVENTS, GET_EVENT_BY_SLUG, GET_PAST_EVENTS, GET_UPCOMING_EVENTS } from '../../constants/apiRoutes';

// Simulate API delay
const delay = (ms) => new Promise(resolve => setTimeout(resolve, ms));

export const eventService = {
  // Get all events (both upcoming and past)
  async getAllEvents() {
    try {
      const response = await api.get(GET_ALL_EVENTS);
      return response.data;
    } catch (error) {
      console.error('Error fetching all events:', error);
      throw error;
    }
  },

  // Get upcoming events
  async getUpcomingEvents() {
    try {
      const response = await api.get(GET_UPCOMING_EVENTS);
      return response.data;
    } catch (error) {
      console.error('Error fetching upcoming events:', error);
      throw error;
    }
  },

  // Get past events
  async getPastEvents() {
    try {
      const response = await api.get(GET_PAST_EVENTS);
      return response.data;
    } catch (error) {
      console.error('Error fetching past events:', error);
      throw error;
    }
  },

  // Get event by slug
  async getEventBySlug(slug) {
    try {
      const response = await api.get(GET_EVENT_BY_SLUG(slug));
      return response.data;
    } catch (error) {
      console.error('Error fetching event:', error);
      throw error;
    }
  }
}; 