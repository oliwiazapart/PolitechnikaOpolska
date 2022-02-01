mlist = []
suma = 0

n = int(input())

for i in range(0, n):
    m = float(input())
    mlist.append(m)

for j in mlist:
    suma = suma + j 
    
srednia = suma / len(mlist)
print()
print(srednia)

    