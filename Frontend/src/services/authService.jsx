import api from '../utils/api';
import { LOGIN, REGISTER } from '../constants/apiRoutes';

export const login = async (email, password) => {
  const response = await api.post(LOGIN, { email, password });
  return response.data;
};

export const register = async (email, password) => {
  const response = await api.post(REGISTER, { email, password });
  return response.data;
}; 