from math import sin

l = []
n = int(input())

for i in range(1,n+1):
    i = sin(i)
    l = l +[i]
    i = i+1
    
print()
print("Największa: ", max(l))
print("Najmniejsza: ", min(l))