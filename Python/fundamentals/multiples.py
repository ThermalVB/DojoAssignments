
for i in range(1001):
    print i

for i in xrange(5, 100005, 5):
    print i

a = [1, 2, 5, 10, 255, 3]
sum1 = 0
for i in a:
    sum1 = sum1 + i
    
avg = sum1 / len(a)