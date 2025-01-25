import React, { useState } from 'react';
import axios from 'axios';
import './styles/Chatbot.css';

const Chatbot = () => {
  const [isOpen, setIsOpen] = useState(false);
  const [messages, setMessages] = useState([]);
  const [input, setInput] = useState('');

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

      try {
        const response = await axios.post('http://127.0.0.1:8080/ask', { query: input });
        const botMessage = { sender: 'bot', text: response.data.answer };
        setMessages([...messages, userMessage, botMessage]);
      } catch (error) {
        console.error('Error fetching response:', error);
      }
    }
  };

  return (
    <div className={`chatbot-container ${isOpen ? 'open' : ''}`}>
      <div className="chatbot-icon" onClick={toggleChatbox}>
        💬
      </div>
      {isOpen && (
        <div className="chatbox">
          <div className="chatbox-header">
            <h4>Chatbot</h4>
            <button onClick={toggleChatbox}>✖</button>
          </div>
          <div className="chatbox-messages">
            {messages.map((msg, index) => (
              <div key={index} className={`message ${msg.sender}`}>
                {msg.text}
              </div>
            ))}
          </div>
          <div className="chatbox-input">
            <input
              type="text"
              value={input}
              onChange={handleInputChange}
              placeholder="Type a message..."
            />
            <button onClick={handleSendMessage}>Send</button>
          </div>
        </div>
      )}
    </div>
  );
};

export default Chatbot; 