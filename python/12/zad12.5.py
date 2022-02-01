def wyswietl(A):
    for i in A:
        print('\t'.join(map("{:>6.2f}".format,i)))
        
def Gauss2(A):
    a = [x[:] for x in A]    
    for i in range(min(len(a), len(a[0]))):
        for j in range(i, len(a)):
            if a[j][i] != 0:
                a[i], a[j] = a[j], a[i]
                break
        else: 
            continue
        for k in range(i, len(a[i]))[::-1]:
            a[i][k] /= a[i][i]
        for l in set(range(len(a))) - {i}:
            for m in range(i, len(a[l]))[::-1]:
                a[l][m] -= a[i][m] * a[l][i]
    return a
        
    
    
a = [[1, 1, 1, 4], 
    [1, -1, 1, 2],
    [1, 1, -1, 1]]
aG = Gauss2(a)
print(wyswietl(a))
print(wyswietl(aG))
print(aG[-3][0],"x1 = ", aG[-3][-1])
print(aG[-2][1],"x2 = ", aG[-2][-1])
print(aG[-1][2],"x3 = ", aG[-1][-1])
print()

b = [[-2, 1, 1, 1], 
    [1, -2, 1, 1],
    [1, 1, -2, 1]]
bG = Gauss2(b)
print(wyswietl(b))
print(wyswietl(bG))
print(bG[-3][0],"x1 ", bG[-3][2],"x3 = ", bG[-3][-1])
print(bG[-2][1],"x2 ", bG[-2][2],"x3 = ", bG[-2][-1])
print(bG[-1][2]," = ", bG[-1][-1])
print("Układ sprzeczny")
print()

c = [[1, -2, -1, 3, 5], 
    [2, -4, -2, 6, 10],
    [2, 1, 0, 1, 20]]
cG = Gauss2(c)
print(wyswietl(c))
print(wyswietl(cG))
print(cG[-3][0], "x1 ",cG[-3][2], "x3 + ", cG[-3][3], "x4 = ", cG[-3][-1])
print(cG[-2][1], "x2 + ",cG[-2][2], "x3 ", cG[-2][3], "x4 = ", cG[-2][-1])
print(cG[-1][2], " = ", cG[-1][-1])
print("Układ nieoznaczony")
print()