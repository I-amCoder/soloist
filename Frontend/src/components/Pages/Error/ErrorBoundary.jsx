import React from 'react';
import Button from '../../UI/Button';
import './styles/Error.css';

class ErrorBoundary extends React.Component {
  constructor(props) {
    super(props);
    this.state = { hasError: false, error: null };
  }

  static getDerivedStateFromError(error) {
    return { hasError: true, error };
  }

  componentDidCatch(error, errorInfo) {
    console.error('Error caught by boundary:', error, errorInfo);
  }

  handleRefresh = () => {
    window.location.reload();
  };

  render() {
    if (this.state.hasError) {
      return (
        <div className="error-container">
          <div className="error-content">
            <h1 className="error-title">Oops!</h1>
            <h2 className="error-subtitle">Something went wrong</h2>
            <p className="error-description">
              We're sorry for the inconvenience. Please try refreshing the page.
            </p>
            <Button variant="primary" onClick={this.handleRefresh}>
              Refresh Page
            </Button>
          </div>
        </div>
      );
    }

    return this.props.children;
  }
}

export default ErrorBoundary; 