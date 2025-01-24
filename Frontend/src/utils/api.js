import axios from 'axios';

const api = axios.create({
  baseURL: 'https://localhost:7015/api', // Update with your API base URL
  headers: {
    'Content-Type': 'application/json',
  },
});

export default api; 