import React, { useState, useEffect, useRef } from 'react';
import axios from 'axios';
import './styles/Chatbot.css';
import { FaTimes } from 'react-icons/fa';
import { DotLoader } from 'react-spinners';

const Chatbot = () => {
  const [isOpen, setIsOpen] = useState(false);
  const [messages, setMessages] = useState([]);
  const [input, setInput] = useState('');
  const [isLoading, setIsLoading] = useState(false);
  const messagesEndRef = useRef(null);
  const inputRef = useRef(null);

  const toggleChatbox = () => {
    setIsOpen(!isOpen);
  };

  const handleInputChange = (e) => {
    setInput(e.target.value);
  };

  const handleSendMessage = async () => {
    if (input.trim()) {
      const userMessage = { sender: 'user', text: input };
      setMessages([...messages, userMessage]);
      setInput('');
      setIsLoading(true);

      try {
        const response = await axios.post('http://127.0.0.1:8080/ask', JSON.stringify({ query: input }), {
          headers: {
            'Content-Type': 'application/json'
          }
        });
        const botMessage = { sender: 'bot', text: response.data.response };
        console.log(botMessage);
        setMessages([...messages, userMessage, botMessage]);
      } catch (error) {
        console.error('Error fetching response:', error);
      } finally {
        setIsLoading(false);
        inputRef.current.focus();
      }
    } else {
      inputRef.current.focus();
    }
  };

  const handleKeyPress = (e) => {
    if (e.key === 'Enter' && !isLoading) {
      handleSendMessage();
    }
  };

  useEffect(() => {
    if (messagesEndRef.current) {
      messagesEndRef.current.scrollIntoView({ behavior: 'smooth' });
    }
  }, [messages]);

  return (
    <div className={`chatbot-container ${isOpen ? 'open' : ''}`}>
      {!isOpen && (
        <div className="chatbot-icon" onClick={toggleChatbox}>
          💬
        </div>
      )}
      {isOpen && (
        <div className="chatbox">
          <div className="chatbox-header" style={{ color: 'white' }}>
            <h4>ACM Chatbot</h4>
            <button className="close-button" onClick={toggleChatbox}>
              <FaTimes />
            </button>
          </div>
          <div className="chatbox-messages">
            {messages.map((msg, index) => (
              <div key={index} className={`message ${msg.sender} ${msg.sender === 'user' ? 'message-right' : 'message-left'}`}>
                {msg.text}
              </div>
            ))}
            {isLoading && (
              <div className="message bot message-left">
                <DotLoader size={24} color="#36d7b7" />
              </div>
            )}
            <div ref={messagesEndRef} />
          </div>
          <div className="chatbox-input">
            <input
              ref={inputRef}
              type="text"
              value={input}
              onChange={handleInputChange}
              onKeyPress={handleKeyPress}
              placeholder="Type a message..."
              disabled={isLoading}
            />
            <button
              onClick={handleSendMessage}
              disabled={isLoading}
              style={{ opacity: isLoading ? 0.5 : 1 }}
            >
              Send
            </button>
          </div>
        </div>
      )}
    </div>
  );
};

export default Chatbot; 