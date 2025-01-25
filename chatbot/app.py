import openai
from dotenv import load_dotenv
import os
# Your OpenAI API key
load_dotenv()

# Set up OpenAI API key from the environment variable
openai.api_key = os.getenv("OPENAI_API_KEY")

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
   	 model="gpt-4-turbo",  # Change from gpt-4-mini to gpt-4-turbo
   	 messages=[{"role": "system", "content": prompt}]
    )


    return response['choices'][0]['message']['content'].strip()

# Example usage
while True:
    user_query = input("Ask ACM Bot: ")
    if user_query.lower() == "exit":
        break
    response = ask_acm_bot(user_query)
    print("ACM Bot:", response)

