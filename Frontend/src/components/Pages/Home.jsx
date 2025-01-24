import React from 'react';
import Hero from './Home/Hero';
import ExecutiveMembers from './Home/ExecutiveMembers';

const Home = () => {
  return (
    <div className="home-container">
      <Hero />
      <ExecutiveMembers />
      {/* Other sections will be added here */}
    </div>
  );
};

export default Home;