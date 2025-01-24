import React, { useState, useEffect } from 'react';
import LoadingSpinner from '../UI/LoadingSpinner';
import Button from '../UI/Button';
import './styles/Dashboard.css';

const Dashboard = () => {
  const [isLoading, setIsLoading] = useState(true);
  const [userStats, setUserStats] = useState({
    projectsCount: 0,
    eventsParticipated: 0,
    upcomingEvents: 0
  });

  useEffect(() => {
    // Simulate loading user data
    const loadDashboardData = async () => {
      try {
        setIsLoading(true);
        // Mock data - replace with actual API calls
        await new Promise(resolve => setTimeout(resolve, 1000));
        setUserStats({
          projectsCount: 5,
          eventsParticipated: 3,
          upcomingEvents: 2
        });
      } catch (error) {
        console.error('Error loading dashboard data:', error);
      } finally {
        setIsLoading(false);
      }
    };

    loadDashboardData();
  }, []);

  if (isLoading) {
    return <LoadingSpinner />;
  }

  return (
    <div className="dashboard-container">
      <header className="dashboard-header">
        <h1>Welcome to your Dashboard!</h1>
        <p className="text-muted">Here's your hackathon journey overview</p>
      </header>

      <div className="dashboard-stats">
        <div className="stat-card">
          <h3>{userStats.projectsCount}</h3>
          <p>Projects</p>
        </div>
        <div className="stat-card">
          <h3>{userStats.eventsParticipated}</h3>
          <p>Events Participated</p>
        </div>
        <div className="stat-card">
          <h3>{userStats.upcomingEvents}</h3>
          <p>Upcoming Events</p>
        </div>
      </div>

      <section className="dashboard-actions">
        <h2>Quick Actions</h2>
        <div className="action-buttons">
          <Button variant="primary" onClick={() => {}}>
            Create New Project
          </Button>
          <Button variant="secondary" onClick={() => {}}>
            Browse Events
          </Button>
        </div>
      </section>

      <section className="dashboard-recent">
        <h2>Recent Activity</h2>
        <div className="activity-list">
          <p className="text-muted">No recent activity</p>
        </div>
      </section>
    </div>
  );
};

export default Dashboard; 