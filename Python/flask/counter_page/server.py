from flask import Flask, render_template, redirect, request, session, flash
app = Flask(__name__)
app.secret_key = 'ThisIsSecret'

def sumSessionCounter():
  try:
    session['counter'] += 1
  except KeyError:
    session['counter'] = 1

@app.route('/')
def index():
    sumSessionCounter()
    return render_template("index.html")

@app.route('/count2')
def count2():
    session['counter'] += 1
    return redirect('/')
@app.route('/reset')
def reset():
    session['counter'] = -1
    return redirect('/')



app.run(debug=True)
