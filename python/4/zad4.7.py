from math import sqrt

s = 1.0
i = 1.0

while i < 1000:
    i = i + 1
    s = s + 1/(i**2)
    
print(s) 

print(sqrt(6*s))

print("s to liczba, która jest odpowiedzą na problem bazylejski i jaką odkrył L. Euler")