import websocket
import json

def on_message(ws, message):
    print("Received response:", message)
    ws.close()

def on_error(ws, error):
    print("Error:", error)

def on_close(ws, close_status_code, close_msg):
    print("Closed connection")

def on_open(ws):
    # Send a query message to the WebSocket server
    query = "What does ACM do?"
    print("Sending message:", query)
    message = json.dumps(query)
    ws.send(message)

if __name__ == "__main__":
    # Update WebSocket URL to match the Flask server's port (5002)
    ws_url = "ws://127.0.0.1:5002/"  # Correct the port to 5002
    
    # Create a WebSocket connection and test communication
    ws = websocket.WebSocketApp(ws_url,
                                on_message=on_message,
                                on_error=on_error,
                                on_close=on_close)
    ws.on_open = on_open
    ws.run_forever()
