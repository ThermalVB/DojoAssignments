from flask import Flask, render_template, redirect, request, session, flash
app = Flask(__name__)
app.secret_key = 'ThisIsSecret'

@app.route('/')
def index():
  return render_template("index.html")
# this route will handle our form submission

@app.route('/users', methods=['POST'])
def create_user():
   print "Got Post Info"
   # notice how the key we are using to access the info corresponds with the names
   # of the inputs from our html form
   name = request.form['name']
   email = request.form['email']
   return redirect('/') # redirects back to the '/' route


@app.route('/show')
def show_user():
  return render_template('user.html')

app.run(debug=True)
