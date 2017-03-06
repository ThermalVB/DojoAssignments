from django.shortcuts import render, redirect, HttpResponseRedirect
from .models import User, Item
from django.contrib import messages
from django.contrib.auth import logout

def index(request):
    return render(request, 'exam/index.html')

def register(request):
    viewsResponse = User.objects.add_user(request.POST)
    if viewsResponse['isRegistered']:
        request.session['user_id'] = viewsResponse['user'].id
        request.session['name'] = viewsResponse['user'].name
        request.session['username'] = viewsResponse['user'].username
        request.session['date_hired'] = viewsResponse['user'].date_hired
        return redirect('exam:dashboard')
    else:
        for error in viewsResponse['errors']:
            messages.error(request, error)
        return redirect('exam:index')

def dashboard(request):
    user = request.session['user_id']
    context = {
    "my_items" : Item.objects.filter(user = user)|Item.objects.filter(added_by = user),
    "others_items" : Item.objects.exclude(user = user).exclude(added_by = user)
    }
    print context
    print Item.objects.all()
    print User.objects.all()
    return render(request, 'exam/dashboard.html', context)

def login(request):
    viewsResponse = User.objects.login_user(request.POST)
    print viewsResponse
    if viewsResponse['isLoggedIn']:
        request.session['user_id'] = viewsResponse['user'].id
        request.session['username'] = viewsResponse['user'].username
        return redirect('exam:dashboard')

    else:
        for error in viewsResponse['errors']:
            messages.error(request, error)
        return redirect('exam:index')

def create(request):
    print id
    return render(request, 'exam/create.html')

def create_item(request):
    print "*" * 50
    print request.POST
    user = request.session['user_id']
    viewsResponse = Item.objects.add_item(request.POST, user)
    print viewsResponse['item'].item_name
    print viewsResponse['item'].added_by
    print viewsResponse['item'].date_added
    print "&" * 50


    if viewsResponse['itemExists']:
        print "itemexists"
        # request.session['item_name'] = viewsResponse['item'].item_name
        # request.session['added_by'] = viewsResponse['item'].added_by
        # request.session['date_added'] = viewsResponse['item'].date_added
        return redirect('exam:dashboard')
    else:
        print "got errors"
        for error in viewsResponse['errors']:
            messages.error(request, error)
        return HttpResponseRedirect('exam/dashboard.html')

def wish_items(request, id):
    user = id
    print request.POST
    item = Item.objects.get(id = user)
    print item
    users = item.user.all()
    print "*" * 50
    print item.added_by.username
    print "*" * 50
    context = {
    'created_by' : item.added_by,
    'item': Item.objects.get(id = user),
    'users' : item.user.all()
    }
    print "*" * 50
    print context['item']
    print context['users']
    return render(request, 'exam/wish_items.html', context)

def add_my_item(request, id):
    print id

    user = User.objects.get(id = request.session['user_id'])
    item = Item.objects.get(id = id)
    print item.user.count()
    item.user.add(user)
    print item.user.count()
    print "&" * 50
    return redirect('exam:dashboard')

def remove_item(request, id):
    print id
    print request.POST
    user = User.objects.get(id = request.session['user_id'])
    print user
    item = Item.objects.get(id = id)
    print item
    item.delete()
    return redirect('exam:dashboard')

def logout(request):
    request.session.clear()
    return redirect('exam:index')
