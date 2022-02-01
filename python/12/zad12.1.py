import random

def losowa(a,b,n):
    A = [[random.randint(1,n) for i in range(a)] for j in range(b)]
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
        
    
    
A = losowa(4,3,5)
print(wyswietl(A))
print()
print(wyswietl(Gauss(A)))