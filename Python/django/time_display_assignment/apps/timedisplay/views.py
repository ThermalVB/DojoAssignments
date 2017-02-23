from django.shortcuts import render, HttpResponse

# Create your views here.
import time
def index(request):
    content = {
    "time": time.strftime("%a, %d %b %Y %H:%M:%S")
    }
    return render(request,'index.html',content)
