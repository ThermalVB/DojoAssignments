import re
from flask import Flask, render_template, redirect, request, session, flash
from mysqlconnection import MySQLConnector
app = Flask(__name__)
mysql = MySQLConnector(app,'email_validation')
app.secret_key = 'ThisIsSecret'
email_regex = re.compile(r'\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}\b')

@app.route('/')
def index():
    return render_template("index.html")

@app.route('/input', methods=['POST'])
def create():
    # Write query as a string. Notice how we have multiple values
    # we want to insert into our query.
    if re.match(email_regex,request.form['email']):
        query = "INSERT INTO user (first_name, last_name, email, created_at, updated_at) VALUES (:first_name, :last_name, :email, NOW(), NOW());"
        # We'll then create a dictionary of data from the POST data received.
        data = {
                 'first_name': request.form['first_name'],
                 'last_name': request.form['last_name'],
                 'email':  request.form['email']
               }
        # Run query, with dictionary values injected into the query.
        mysql.query_db(query, data)
        return redirect('/success')
    else:
        flash('You have entered an invalid email')
        users = mysql.query_db("SELECT * FROM user")
        return render_template('success.html',all_users=users)

@app.route('/success')
def success():
    users = mysql.query_db("SELECT * FROM user")
    print users
    return render_template('success.html',all_users=users)

app.run(debug=True)                       # Run the app in debug mode.
