import random
import numpy as np

def wyswietl(A):
    for i in A:
        print('\t'.join(map(str,i)))
        
def losowa(a,b,n):
    A = [[random.randint(1,n) for i in range(a)] for j in range(b)]
    return A

def zamW(A,i,j):
    a = np.array(A)
    a[[i,j]]= a[[j,i]]
    return a

def przemW(A,i,k):
    a = np.array(A)
    a[i] = [i*k for i in A[i]]
    return a

def dodajW(A,i,j,k):
    a = np.array(A)
    list0=[i,j]
    for t in range(0,k):
        a[i] = np.sum(a[list0,:],axis=0)
    return a

A = losowa(3,3,10)

wyswietl(A)
print()
wyswietl(zamW(A,0,1))
print()
wyswietl(przemW(A,0,5))
print()
wyswietl(dodajW(A,0,1,2))