import random

def losowa(a,b,n):
    A = [[random.randint(1,n) for i in range(a)] for j in range(b)]
    return A

def wyswietl(A):
    for i in A:
        print('\t'.join(map(str,i)))
        
        
def det(A):
    if len(A) <= 0:
        return None
    if len(A) == 1:
        return A[0][0]
    else:
        a = 0
        for i in range(len(A)):
            n = [[k[j] for j in range(len(A)) if j != i] for k in A[1:]]
            if i % 2 == 0:
                a += A[0][i] * det(n)
            else:
                a -= A[0][i] * det(n)
        return a
    
    
A = losowa(3,3,10)
wyswietl(A)
print(det(A))
