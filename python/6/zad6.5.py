l = []

for j in range(0,31):
    licz = (3 ** j) - (2 ** j)
    l.append(licz)
    
l2 = []

for i in l:
    resz = i % 19
    l2.append(resz)
    
    
print(10 in l2)
print(11 in l2)

n = input()

if 0 <= int(n) <= 18:
    print(l2)
else:
    print("Zly przedzial")

if int(n) in l2:
    print(l2.count(int(n)))
else:
    print("Nie ma tej liczby")