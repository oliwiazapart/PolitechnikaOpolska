l = []
n = int(input())

for i in range(0,n):
    i = int(input())
    l = l +[i]
    i = i+1
    
print()
print("Największa: ", max(l))
print("Najmniejsza: ", min(l))

