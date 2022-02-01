import random 

def zera(a,b):
    A = [[0 for i in range(a)] for j in range(b)]
    return A

def wyswietl(A):
    for i in A:
        print('\t'.join(map(str,i)))
        
def losowa(a,b,n):
    A = [[random.randint(1,n) for i in range(a)] for j in range(b)]
    return A

def dodaj(A,B):
    if len(A) != len(B):
        C = []
    else: 
        C = zera(len(A),len(B))
        for i in range(len(A)):
            for j in range(len(A[0])):
                C[i][j] = A[i][j] + B[i][j]
    return C
    
A = losowa(5,5,10)
B = losowa(5,5,10)

wyswietl(A)
print()
wyswietl(B)
print()
wyswietl(dodaj(A,B))