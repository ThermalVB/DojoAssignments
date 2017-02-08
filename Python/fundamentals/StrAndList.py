#find and replace
str = "If monkeys like bananas, then I must be a monkey!"
str.count("monkey")
str.replace("monkey", "alligator")
print str
#min and max
x = [2,54,-2,7,12,98]
min(x)
max(x)
print min
print max
#first and last
x = ["hello",2,54,-2,7,12,98,"world"]
print(x[0], x[len(x)-1])
y = [x[0], x[len(x)-1]]
print y
#new list
orgArr = [19,2,54,-2,7,12,98,32,10,-3,6]
orgArr.sort()
negArr = []
j = 0

for i in orgArr:
    if i < 0:
        negArr.append(i)

while True:
    if orgArr[0] < 0:
        orgArr.remove(orgArr[0])
    else:
        break

finArr = []
finArr.append(negArr)

while j < len(orgArr):
    finArr.append(orgArr[j])
    j += 1
    
print orgArr
print negArr
print finArr