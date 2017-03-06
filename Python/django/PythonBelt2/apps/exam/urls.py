from django.conf.urls import url
from . import views

urlpatterns = [
    url(r'^$', views.index, name = 'index'),
    url(r'^register$', views.register, name = 'register'),
    url(r'^dashboard$', views.dashboard, name = 'dashboard'),
    url(r'^login$', views.login, name = 'login'),
    url(r'^create$', views.create, name = 'create'),
    url(r'^logout$', views.logout, name = 'logout'),
    url(r'^create_item$', views.create_item, name = 'create_item'),
    url(r'^remove_item/(?P<id>\w+)$', views.remove_item, name = 'remove_item'),
    url(r'^wish_items/(?P<id>\w+)$', views.wish_items, name = 'wish_items'),
    url(r'^add_my_item/(?P<id>\w+)$', views.add_my_item, name = 'add_my_item')
]
