from flask import Flask, render_template, redirect, request, session, flash

app = Flask(__name__)
app.secret_key = 'mykey'
bcrype = Bcrypt(app)
mysql = MySQLConnector(app, 'login_reg')

@app.route('/')
def index():
    return render_template("index.html")

@app.route('/register', methods=['POST'])
def register():
    print request.form
    errors = []

    if len(request.form['first_name']) < 2:
        errors.append('First name is too short')
    if len(request.form['last_name']) < 2:
        errors.append('Last name is too short')
    if not NAME_REGEX.match(request.form['first_name']):
        errors.append('First name must be letters only')
    if not NAME_REGEX.match(request.form['last_name']):
        errors.append('Last name must be letters only')
    if not EMAIL_REGEX.match(request.form['email']):
        errors.append('Please enter a valid email')
    if len(request.form['password']) < 8:
        errors.append('Passwords must be longer than 8 characters')
    if not request.form['password'] == request.form['confirm_password']:
        errors.append('Passwords must match')

    print errors

    if errors:
        for error in errors:
            flash(error)

        return redirect('/')

    else:
        hashed_pw = bcrypt.generate_password_hash(request.form['password'])
        print hashed_pw
        query = "INSERT into users (first_name, last_name, email, password, created_at, updated_at) VALUES (:first_name, :last_name, :email, :password, :created_at, :updated_at)"
        data = {
            'first_name': request.form['first_name'],
            'last_name': request.form['last_name'],
            'email': request.form['email'],
            'password': hashed_pw
        }

        user_id = mysql.query_db(query, data)
        session['user_id'] = user_id
        return redirect('/success')

    return redirect('/')

@app.route('/login',methods=['POST'])
def login():

    query = "SELECT * FROM users where email = :email"
    data = {
        'email': request.form['email'],
    }
    user = mysql.query_db(query, data)

    if user:
        if bcrypt.check_password_hash(user[0].password, request.form['password']):
            session['user_id'] = user[0].id
            return redirect('/')
        else:
            flash('Invalid email/password combination')
            return redirect('/')

@app.route('/success')
def success():
    

@app.route('/logout')
def logout():
    session.clear
    return redirect('/')

app.run(debug=True)                       # Run the app in debug mode.
