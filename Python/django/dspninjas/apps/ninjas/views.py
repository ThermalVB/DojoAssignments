from django.shortcuts import render, HttpResponse

# Create your views here.
def index(request):
    return render(request, "ninjas/index.html")

def group(request):
    return render(request, "ninjas/group.html")

def id(request, id):
    context = {
    "id" : id,
    "purple" : 'don.gif',
    "red" : 'rap.jpg',
    "blue" : 'leo.jpg',
    "orange" : 'mic.gif',
    "april" : 'april.jpg'
    }
    return render(request, "ninjas/id.html", context)
