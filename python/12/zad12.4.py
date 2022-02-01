import random
import numpy

def losowa(a,b,n):
    A = [[random.randint(1,n) for i in range(a)] for j in range(b)]
    return A


def wyswietl(A):
    for i in A:
        print('\t'.join(map("{:>6.2f}".format,i)))
        
def odwr(A):
    a = [x[:] + [0 for y in x] for x in A] 
    for z in range(len(a)):
        a[-z - 1][-z - 1] = 1
    
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
    return [a[i][int(len(a[i])/2):] for i in range(len(a))]

def pomnoz(A,B):
    res = [[0 for x in range(3)] for y in range(3)] 
    for i in range(len(A)):
        for j in range(len(B[0])):
            for k in range(len(B)):
                res[i][j] += A[i][k] * B[k][j]
                
    return res


A = losowa(3,3,5)
print(wyswietl(A))
print()
print(wyswietl(odwr(A)))
print()
print(wyswietl(pomnoz(A, odwr(A))))
