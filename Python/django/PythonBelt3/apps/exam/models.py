from __future__ import unicode_literals

from django.db import models

import re, bcrypt

import datetime

EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+.[a-zA-Z]+$')

class UserManager(models.Manager):
    def register(self, postData):
        #store possbile failed validations
        errors = []
        if len(postData['name']) < 2:
            errors.append("Name must be at least 2 characters")
        if not len(postData['email']):
            errors.append("email is required")
        if not EMAIL_REGEX.match(postData['email']):
            errors.append("email is not valid")
        if len(postData['password']) < 8:
            errors.append("Password must be at least 8 characters")
        if not postData['password'] == postData['confirm_password']:
            errors.append("Passwords must match")
        # if (postData['date_of_birth'] > datetime.date.today()):
        #     errors.append("Date of Birth must be prior to today")
        user = User.objects.filter(email= postData['email'])
        if user:
            errors.append("Email is already registered")
        response = {}
        if errors:
            response['isRegistered'] = False
            response['errors'] = errors
            return response
        else:
            hashedPw = bcrypt.hashpw(postData['password'].encode(),
            bcrypt.gensalt())
            user = self.create(
            name=postData['name'],
            email=postData['email'],
            password=hashedPw,
            date_of_birth = postData['date_of_birth']
            )
            response['isRegistered'] = True
            response['user'] = user
            return response
    def login_user(self, postData):
        user = User.objects.filter(name = postData['name'])
        errors = []
        modelsResponse = {}
        if not user:
            #invalid name
            print "inside"
            errors.append('Invalid name')
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
                #invalid pw/name
                errors.append('Invalid name password combination')
                return modelsResponse

        if errors:
            modelsResponse['isLoggedIn'] = False
            modelsResponse['errors'] = errors

        request.session['current_user'] = postData['name']
        return modelsResponse


class User(models.Model):
    name = models.CharField(max_length= 38)
    email = models.CharField(max_length= 25)
    password = models.CharField(max_length= 100)
    date_of_birth = models.DateField(auto_now_add=False)
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now_add=True)

    objects = UserManager()


class ApptManager(models.Manager):
    def add_appt(self, postData, user_id):
        modelsResponse = {}
        errors = []
        user = User.objects.get(id = user_id)
        print "trying to add appt"
        if len(postData['task']) < 3:
            errors.append("Task must have a name longer than 2 characters")
        if not postData['date'] or not postData['time']:
            errors.append("Task must have an assigned Date and Time")

        if errors:
            print errors
            modelsResponse['apptExists'] = False
            modelsResponse['errors'] = errors
            return modelsResponse

        else:
            print "not returning errors"
            appt = self.create(
            task = postData['task'],
            user = user,
            date = postData['date'],
            time = postData['time']
            )
            modelsResponse['apptExists'] = True
            modelsResponse['appt'] = appt
            appt.save()
            return modelsResponse

            print modelsResponse
            print "if/else conditionals failed"
            return modelsResponse



class Appt(models.Model):
    #choices variable for status field
    STATUS_CHOICES = (
    ("DONE", "Done"),
    ("PENDING", "Pending"),
    ("MISSED", "Missed")
    )

    task = models.CharField(max_length = 50)
    user = models.ForeignKey(User, related_name="user")
    status = models.CharField(max_length = 10, choices=STATUS_CHOICES, default="Pending")
    date = models.DateField(auto_now_add = False)
    time = models.TimeField(auto_now_add = False)
    created_at = models.DateTimeField(auto_now_add = True)
    updated_at = models.DateTimeField(auto_now = True)

    objects = ApptManager()
