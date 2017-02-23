from django.conf.urls import url
from . import views
# Models -- views --- TEMPLATES

urlpatterns = [
    url(r'^$', views.index)
]
