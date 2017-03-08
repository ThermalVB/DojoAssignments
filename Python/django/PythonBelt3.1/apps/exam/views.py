from django.shortcuts import render, redirect, HttpResponseRedirect
from .models import User, Appt
from django.contrib import messages
from django.contrib.auth import logout
import datetime

def index(request):
    return render(request, "exam/index.html")

def register(request):
    viewsResponse = User.objects.register(request.POST)
    if viewsResponse['isRegistered']:
        request.session['user_id'] = viewsResponse['user'].id
        request.session['name'] = viewsResponse['user'].name
        request.session['email'] = viewsResponse['user'].email
        request.session['date_of_birth'] = viewsResponse['user'].date_of_birth
        return redirect('exam:dashboard')
    else:
        for error in viewsResponse['errors']:
            messages.error(request, error)
        return redirect('exam:index')

def dashboard(request):
    user = request.session['user_id']
    date = datetime.date.today()
    context = {
    "my_appts_today" : Appt.objects.filter(user = user)|Appt.objects.filter(date = date),
    "my_appts_future" : Appt.objects.filter(user = user).exclude(date = date),
    "today" : date
    }
    print context
    print Appt.objects.all()
    print User.objects.all()
    return render(request, 'exam/dashboard.html', context)

def login(request):
    viewsResponse = User.objects.login_user(request.POST)
    print viewsResponse
    if viewsResponse['isLoggedIn']:
        request.session['user_id'] = viewsResponse['user'].id
        request.session['email'] = viewsResponse['user'].email
        return redirect('exam:dashboard')

    else:
        for error in viewsResponse['errors']:
            messages.error(request, error)
        return redirect('exam:index')

def create_appt(request):
    print "*" * 50
    print request.POST
    user = request.session['user_id']
    viewsResponse = Appt.objects.add_appt(request.POST, user)
    print "&" * 50

    if viewsResponse['apptExists']:
        print "apptexists"
        return redirect('exam:dashboard')
    else:
        print "got errors"
        for error in viewsResponse['errors']:
            messages.error(request, error)
        return HttpResponseRedirect('/dashboard')

def update(request, id):
    user = request.session['user_id']
    appt=Appt.objects.get(id = id)
    print appt.task
    print appt.status
    print appt.date
    print appt.time

    context = {
    "Task" : appt.task,
    "Status" : appt.status,
    "Date" : appt.date,
    "Time" : appt.time,
    "id" : id
    }
    print id
    return render(request, 'exam/update.html', context)

def update_appt(request, id):
    print "*" * 50
    print request.POST
    newappt = request.POST
    appt = Appt.objects.get(id = id)
    appt.task = newappt['task']
    appt.status = newappt['status']
    appt.date = newappt['date']
    appt.time = newappt['time']
    appt.save()
    print appt.status
    return redirect('exam:dashboard')

def remove_appt(request, id):
    print id
    print request.POST
    user = User.objects.get(id = request.session['user_id'])
    print user
    appt = Appt.objects.get(id = id)
    print appt
    appt.delete()
    return redirect('exam:dashboard')

def logout(request):
    request.session.clear()
    return redirect('exam:index')
