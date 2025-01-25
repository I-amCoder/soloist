import React, { Suspense } from 'react';
import { BrowserRouter as Router, Routes, Route, Navigate } from 'react-router-dom';
import Layout from './components/Layout/Layout';
import LoadingSpinner from './components/UI/LoadingSpinner';
import ErrorBoundary from './components/Pages/Error/ErrorBoundary';
import NotFound from './components/Pages/Error/NotFound';
import AboutUs from './components/Pages/About/AboutUs';
import Chatbot from './components/UI/Chatbot';

// Lazy load components
const Home = React.lazy(() => import('./components/Pages/Home'));
const Team = React.lazy(() => import('./components/Pages/Team'));
const Events = React.lazy(() => import('./components/Pages/Events/Events'));
const EventDetail = React.lazy(() => import('./components/Pages/Events/EventDetail'));
const Projects = React.lazy(() => import('./components/Pages/Projects'));

function App() {
  return (
    <ErrorBoundary>
      <Router>
        <Layout>
          <Suspense fallback={<LoadingSpinner />}>
            <Routes>
              <Route exact path="/" element={<Home />} />
              <Route path="/team" element={<Team />} />
              <Route path="/events" element={<Events />} />
              <Route path="/events/:slug" element={<EventDetail />} />
              <Route path="/projects" element={<Projects />} />
              <Route path="/about" element={<AboutUs />} />
              <Route path="/404" element={<NotFound />} />
              <Route path="*" element={<Navigate to="/404" replace />} />
            </Routes>
          </Suspense>
        </Layout>
        <Chatbot />
      </Router>
    </ErrorBoundary>
  );
}

export default App; 