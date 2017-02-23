from django.conf.urls import url
from . import views
  # ^ So we can call functions from our routes!
urlpatterns = [
    url(r'^$', views.index),
    url(r'^group$', views.group),
    url(r'([/w])', views.id)
]
