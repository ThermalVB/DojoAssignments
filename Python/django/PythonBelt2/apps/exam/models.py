from __future__ import unicode_literals

from django.db import models

import re, bcrypt



class UserManager(models.Manager):
    """docstring for UserManager."""
    def add_user(self, postData):

        errors = []

        if not len(postData['name']):
            errors.append('Name is required')

        if len(postData['name']) < 3:
            errors.append('Name must be at least 2 characters long')

        if not len(postData['username']):
            errors.append('Username is required')

        if len(postData['username']) < 3:
            errors.append('Username must be at least 4 characters long')

        check_username = self.filter(username = postData['username'])

        if check_username:
            errors.append('Sorry username already exists')

        if len(postData['password']) < 8:
            errors.append('Passwords must be at least 8 characters')

        if not postData['password'] == postData['confirm_password']:
            errors.append('Passwords must match')

        modelsResponse = {}

        if errors:
            #failed validation
            modelsResponse['isRegistered'] = False
            modelsResponse['errors'] = errors
        else:
            #passed validation, create a new User
            hashed_password = bcrypt.hashpw(postData['password'].encode(),
            bcrypt.gensalt())
            user = self.create(
            name = postData['name'],
            username = postData['username'],
            password = hashed_password,
            date_hired = postData['date_hired'])
            modelsResponse['isRegistered'] = True
            modelsResponse['user'] = user

            print "user object????"
            user.save()
            request.session['current_user'] = postData['username']

        print modelsResponse
        return modelsResponse

    def login_user(self, postData):
        user = User.objects.filter(username = postData['username'])
        errors = []
        modelsResponse = {}
        if not user:
            #invalid username
            print "inside"
            errors.append('Invalid username')
            modelsResponse['isLoggedIn'] = False
            modelsResponse['errors'] = errors
            return modelsResponse

        else:
            #found user, check passwords
            if bcrypt.checkpw(postData['password'].encode(), user[0].password.encode()):
                #login user
                modelsResponse['isLoggedIn'] = True
                modelsResponse['user'] = user[0]
                return modelsResponse

            else:
                #invalid pw/username
                errors.append('Invalid username password combination')
                return modelsResponse

        if errors:
            modelsResponse['isLoggedIn'] = False
            modelsResponse['errors'] = errors

        request.session['current_user'] = postData['username']
        return modelsResponse

class User(models.Model):
    name = models.CharField(max_length = 50)
    username = models.CharField(max_length = 100)
    password = models.CharField(max_length = 100)
    date_hired = models.CharField(max_length = 50)
    created_at = models.DateTimeField(auto_now_add = True)
    updated_at = models.DateTimeField(auto_now = True)

    objects = UserManager()

class ItemManager(models.Manager):
    def add_item(self, postData, user_id):
        #store possbile failed validations
        modelsResponse = {}
        errors = []
        user = User.objects.get(id = user_id)
        print "trying to add item"
        if len(postData['item_name']) < 4:
            errors.append("Name must be at least 4 characters long!")

        if errors:
            print "errors"
            modelsResponse['itemExists'] = False
            modelsResponse['errors'] = errors
            return modelsResponse
        else:
            print "not returning errors"
            item = self.create(
            item_name = postData['item_name'],
            added_by = user
            )
            modelsResponse['itemExists'] = True
            modelsResponse['item'] = item
            item.save()
            return modelsResponse

        print modelsResponse
        return modelsResponse

class Item(models.Model):
    item_name = models.CharField(max_length = 50)
    added_by = models.ForeignKey(User)
    date_added = models.DateField(auto_now_add = True)
    user = models.ManyToManyField(User, related_name="users")
    created_at = models.DateTimeField(auto_now_add = True)
    updated_at = models.DateTimeField(auto_now = True)

    objects = ItemManager()
