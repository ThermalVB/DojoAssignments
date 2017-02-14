from flask import Flask, render_template

app = Flask(__name__)

def index():
    return render_template("index.html", phrase="hello", times=5)

app.run(debug=True)                       # Run the app in debug mode.
