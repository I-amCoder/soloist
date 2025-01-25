from flask import Flask, jsonify
from flask_socketio import SocketIO, emit
import openai
from dotenv import load_dotenv
import os

# Load environment variables from the .env file
load_dotenv()

app = Flask(__name__)
socketio = SocketIO(app)  # Initialize Flask-SocketIO

load_dotenv()

# Set up OpenAI API key from the environment variable
openai.api_key = os.getenv("OPENAI_API_KEY")

# Default route returning "Hello World" JSON (optional)
@app.route("/", methods=["GET"])
def hello_world():
    return jsonify({"message": "Hello World"})

# Function to query the ACM chatbot using gpt-4-turbo with detailed prompt
def ask_acm_bot(question):
    # Expanded prompt to ensure accurate ACM-specific responses
    prompt = """
    You are an AI chatbot focused solely on providing information about ACM (Association for Computing Machinery), 
    with an emphasis on ACM student chapters in Asia, including Pakistan, and institutions like UMT and GIKI.
    Your responses must be short, to the point, and relevant to ACM.

    If the question is unrelated to ACM, respond with: 'I can't respond as I am only for ACM society.'

    Example Queries and Expected Responses:
    - What does ACM do? -> ACM advances computing as a science and profession.
    - How can I join ACM? -> Visit the ACM website and sign up for membership.
    - What are ACM student chapters? -> They are university-based groups promoting ACM activities.
    - Who can join ACM UMT chapter? -> Any UMT student with an interest in computing.
    - Tell me about NASA. -> I can't respond as I am only for ACM society.

    Answer the following question based on the guidelines above.
    Question: {}
    """.format(question)
    
    response = openai.ChatCompletion.create(
        model="gpt-4-turbo",  # Using gpt-4-turbo model
        messages=[{"role": "system", "content": prompt}]
    )

    return response['choices'][0]['message']['content'].strip()

# WebSocket event for handling the chat query
@socketio.on('ask_acm_chatbot')
def handle_chat_query(query):
    # Get the query from the WebSocket message
    response = ask_acm_bot(query)
    
    # Emit the response back to the client
    emit('chat_response', {'response': response})

if __name__ == "__main__":
    socketio.run(app, debug=True, host="127.0.0.1", port=5002)

