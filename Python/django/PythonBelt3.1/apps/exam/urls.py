from django.conf.urls import url
from . import views

urlpatterns = [
    url(r'^$', views.index, name = 'index'),
    url(r'^register$', views.register, name = 'register'),
    url(r'^dashboard$', views.dashboard, name = 'dashboard'),
    url(r'^login$', views.login, name = 'login'),
    url(r'^create_appt$', views.create_appt, name = 'create_appt'),
    url(r'^update/(?P<id>\w+)$', views.update, name = 'update'),
    url(r'^update_appt/(?P<id>\w+)$', views.update_appt, name = 'update_appt'),
    url(r'^remove_appt/(?P<id>\w+)$', views.remove_appt, name = 'remove_appt'),
    url(r'^logout$', views.logout, name = 'logout')
]
