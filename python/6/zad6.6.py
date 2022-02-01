l = [1]

for i in range(2,101):
    licz = 1/i
    l.append(licz)
    
print(sum(l))    
print(min(l))    
print(max(l))    

from math import factorial

z= factorial(1000)

sz = str(z)

lz = list(sz)

lz = [int(i) for i in lz]

print(sum(lz))