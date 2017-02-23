from django.shortcuts import render
#CONTROLLER!!!
# Create your views here.
def index(request):
    print("print")
    return render(request, "first_app/index.html")
