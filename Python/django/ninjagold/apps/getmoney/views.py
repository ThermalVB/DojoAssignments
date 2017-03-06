from django.shortcuts import render, redirect, HttpResponseRedirect

# Create your views here.
def index(request):
    return render(request, "getmoney/index.html")

def get_money(request):
    print "getting money"
    building = request.post['building']
    gold = 0
    if building == farm:
        print "farm"
        gold += random(randint(10, 20))

    if building == cave:
        gold += random(randint(5, 10))

    if building == house:
        gold += random(randint(2, 5))

    if building == casino:
        gold += random(randint(-50, 50))

    request.session['gold'] = gold
    print request.session['gold']
    print gold
    return redirect('index')
