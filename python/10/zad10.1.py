t1 = (1, 3, 5.79, "kot")
t2 = (2, 4, 6.8)

print(t1[2], t2[1], t1[-3])

print(t1+t2)
print(t1*2)
print(len(t1))
print(max(t2))

l = list(t2)
del t2
l[0] = 1
print(l)
t2 = tuple(l)
print(t2)