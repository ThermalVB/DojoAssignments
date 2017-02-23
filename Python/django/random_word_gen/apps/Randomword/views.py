from django.shortcuts import render, HttpResponse
import random
import string
allowed_chars = ''.join((string.lowercase, string.uppercase, string.digits))

def index(request):
    if 'count' not in request.session:
        request.session['count'] = 1
    else:
        request.session['count'] += 1
    request.session['string'] = ''.join(random.choice(allowed_chars) for _ in range(14))
    return render(request, 'Randomword/index.html')


from django.shortcuts import render
