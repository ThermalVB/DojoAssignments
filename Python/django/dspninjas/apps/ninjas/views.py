from django.shortcuts import render, HttpResponse

# Create your views here.
def index(request):
    return render(request, "ninjas/index.html")

def group(request):
    return render(request, "ninjas/group.html")

def id(request, id):
    if id == 'purple':
        context = {
        'image' : 'don.gif'
        }
    elif id == 'red':
        context = {
        'image' : 'rap.jpg'
        }
    elif id == 'blue':
        context = {
        'image' : 'leo.jpg'
        }
    elif id == 'orange':
        context = {
        'image' : 'mic.gif'
        }
    else:
        context = {
        'image' : 'april.jpg'
        }
    print id
    print context
    return render(request, "ninjas/id.html", context)
