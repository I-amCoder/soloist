import React from 'react';
import Hero from './Home/Hero';
import ExecutiveMembers from './Home/ExecutiveMembers';
import HomeEvents from './Home/Events';

const Home = () => {
  return (
    <div className="home-container">
      <Hero />
      <HomeEvents />
      <ExecutiveMembers />
      {/* Other sections will be added here */}
    </div>
  );
};

export default Home;