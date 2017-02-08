import random
def scores_and_grades():
    for i in range(10):       
        temp = random.randint(0,100)
        print temp
        if temp > 89:
            print "Score: ", temp, "; Your grade is A"
        elif temp > 79:
            print "Score: ", temp, "; Your grade is B"
        elif temp > 69:
            print "Score: ", temp, "; Your grade is C"
        elif temp > 59:
            print "Score: ", temp, "; Your grade is D"
        else:
            print "Score: ", temp, "; Your grade is F"