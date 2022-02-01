import random
import numpy as np

def losowa(a,b,n):
    A = [[random.randint(0,n) for i in range(a)] for j in range(b)]
    return A


def wyswietl(A):
    for i in A:
        print('\t'.join(map("{:>6.2f}".format,i)))
        
def Gauss(A):
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
        for l in range(i + 1, len(a)):
            for m in range(i, len(a[l]))[::-1]:
                a[l][m] -= a[i][m] * a[l][i]
    return a

def rz(A):
    a = np.array(A)
    zeros = 0
    result = np.all((a == 0), axis=1)
    for i in range(len(result)):
        if result[i]:
            zeros += 1
    numrows = np.shape(a)[0]
    rzad = numrows - zeros
    print("Macierz jest rzędu:", rzad)
    if rzad < 3:
       print(wyswietl(A))
       input("Press Enter to continue...")


liczbagenermac = 50
for i in range(0, liczbagenermac):
    A = losowa(4,3,3)
    print(rz(Gauss(A)))