import random
heads = 0
tails = 0
for i in xrange(1, 5001):
    temp = random.random()
    if round(temp) == 1:
        heads = heads + 1
        #print "heads"
    else:
        tails = tails + 1
        #print "tails"
print heads
print tails