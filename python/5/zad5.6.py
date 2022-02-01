l = [5, 28, 43, 14, 67, 93, 100, 19, 52, 234]
print(l)

l2 = l.copy()
l2.remove(5)
l2.insert(9,5)
print(l2)

l3 = l.copy()
l3.remove(234)
l3.insert(0,234)
print(l3)

l4 = l.copy()
l4.reverse()
print(l4)

l5 = l.copy()
l5 = [i for i in l5 if i % 2 == 0]
print(l5)

l6 = l.copy()
l6 = [i for i in l6 if i % 2 != 0]
l6 = l6[::2]
print(l6)