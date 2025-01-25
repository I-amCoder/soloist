import React from 'react';
import Hero from './Home/Hero';
import ExecutiveMembers from './Home/ExecutiveMembers';
import HomeEvents from './Home/Events';
import HomeProjects from './Home/HomeProjects';

const Home = () => {
  return (
    <div className="home-container">
      <Hero />
      <HomeEvents />
      <HomeProjects />
      <ExecutiveMembers />
      {/* Other sections will be added here */}
    </div>
  );
};

export default Home;