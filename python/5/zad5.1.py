l = [3,'alfa', 2.71,'kot']

for i in range(0,4):
    print(l[i])
    
for j in reversed(range(-4, 0)):
    print(l[j])
    
l = [4,'alfa', 2.71,'pies']

print(l)

l2 = l

print(l, l2)

l2[0] = 10

print(l, l2)

l3 = l.copy()

l3[0] = 30

print(l, l3)