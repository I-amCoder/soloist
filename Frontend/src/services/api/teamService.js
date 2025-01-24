import teamData from '../../data/mock/team.json';

// Simulate API delay
const delay = (ms) => new Promise(resolve => setTimeout(resolve, ms));

export const teamService = {
  // Get all executive members
  async getAllExecutives() {
    await delay(800); // Simulate network delay
    return teamData.executives;
  },

  // Get executive by ID
  async getExecutiveById(id) {
    await delay(500);
    const executive = teamData.executives.find(exec => exec.id === id);
    if (!executive) {
      throw new Error('Executive member not found');
    }
    return executive;
  },

  // Get executives by role
  async getExecutivesByRole(role) {
    await delay(600);
    return teamData.executives.filter(exec => 
      exec.role.toLowerCase().includes(role.toLowerCase())
    );
  }
}; 