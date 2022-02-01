from math import factorial

f= factorial(1000)
sf = str(f)

for i in ['%02d' % j for j in range(0,100)]:
    print(i, "występuje", sf.count(i), "razy")
    
