// Auth Routes
export const AUTH_ROUTES = {
  LOGIN: '/auth/login',
  REGISTER: '/auth/register'
};
export const GET_ALL_EXECUTIVES = '/team/executives';
export const GET_EXECUTIVE_BY_ID = (id) => `/team/executives/${id}`;
export const GET_EXECUTIVES_BY_ROLE = (role) => `/team/executives/role/${role}`;

export const GET_ALL_EVENTS = '/events';
export const GET_UPCOMING_EVENTS = '/events/upcoming';
export const GET_PAST_EVENTS = '/events/past';
export const GET_EVENT_BY_SLUG = (slug) => `/events/${slug}`;

export const GET_ALL_PROJECTS = '/projects';
export const GET_FEATURED_PROJECTS = '/projects/featured';
export const GET_RECENT_PROJECTS = '/projects/recent';
export const GET_PROJECT_BY_ID = (id) => `/projects/${id}`;
export const GET_PROJECTS_BY_TECHNOLOGY = (tech) => `/projects/technology/${tech}`;
export const GET_PROJECTS_BY_HACKATHON = (hackathon) => `/projects/hackathon/${hackathon}`;
export const GET_PROJECTS_BY_STATUS = (status) => `/projects/status/${status}`;
