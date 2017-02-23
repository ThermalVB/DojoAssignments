from django.shortcuts import render
from .models import People
# Create your views here.
def index(request):
    People.objects.create(first_name="Wyatt",
    last_name="H")
    people = People.objects.all()
    print people
    return render(request, "model/index.html")
