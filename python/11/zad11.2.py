def zera(a,b):
    A = [[0 for i in range(a)] for j in range(b)]
    return A

def id(n):
    A = [[0 for i in range(n)] for j in range(n)]
    for i in range(0,n):
        A[i][i] = 1
    return A
    
def wyswietl(A):
    for i in A:
        print('\t'.join(map(str,i)))
        
B = zera(5,5)
C = id(4)
wyswietl(B)
print()
wyswietl(C)