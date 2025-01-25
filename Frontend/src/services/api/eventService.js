import eventsData from '../../data/mock/events.json';

// Simulate API delay
const delay = (ms) => new Promise(resolve => setTimeout(resolve, ms));

export const eventService = {
  // Get all events (both upcoming and past)
  async getAllEvents() {
    await delay(800);
    return {
      upcoming: eventsData.upcoming,
      past: eventsData.past
    };
  },

  // Get upcoming events
  async getUpcomingEvents() {
    await delay(600);
    return eventsData.upcoming;
  },

  // Get past events
  async getPastEvents() {
    await delay(600);
    return eventsData.past;
  },

  // Get event by slug
  async getEventBySlug(slug) {
    await delay(600);
    const allEvents = [...eventsData.upcoming, ...eventsData.past];
    const event = allEvents.find(event => event.slug === slug);
    
    if (!event) {
      throw new Error('Event not found');
    }
    
    return event;
  }
}; 