class Car(object):
    def __init__(self, price, speed, fuel, mileage, tax=0):
        self.price = price
        self.speed = speed
        self.fuel = fuel
        self.mileage = mileage
        if price > 10000:
            self.tax = 0.15
        else:
            self.tax = 0.12
        self.display_all()
        
    def display_all(self):
        print "Price:"+str(self.price)
        print "Speed:"+str(self.speed)
        print "Fuel:"+str(self.fuel)
        print "Mileage"+str(self.mileage)
        print "Tax:"+str(self.tax)