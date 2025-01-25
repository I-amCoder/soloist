import React from 'react';
import Navbar from './Navbar';
import Footer from './Footer';
import Chatbot from '../UI/Chatbot';

const AppLayout = ({ children }) => {
  return (
    <>
      <Navbar />
      <main>{children}</main>
      <Footer />
      <Chatbot />
    </>
  );
};

export default AppLayout; 