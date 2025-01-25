import React from 'react';
import Navbar from './Navbar';
import Footer from './Footer';
import Chatbot from '../UI/Chatbot';

const AppLayout = ({ children }) => {
  return (
    <>
      <Chatbot />
      {/* <Navbar />
      <main>{children}</main>
      <Footer /> */}
    </>
  );
};

export default AppLayout; 