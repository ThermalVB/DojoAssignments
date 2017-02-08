class Bike(object):
    def __init__(self, price, max_speed, miles = 0):
        self.price = price
        self.max_speed
        self.miles = 0
    def displayInfo(self):
        print self.price, self.max_speed, self.miles
    def ride(self):
        self.miles = self.miles + 10
    def reverse(self):
        self.miles = self.miles - 5