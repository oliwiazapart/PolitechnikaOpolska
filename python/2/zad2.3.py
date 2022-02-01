n=int(input('Podaj n: '))
m=int(input('Podaj m: '))

if(n < m):
    for i in range(n,m+1): print(i)
else:
    for i in reversed(range(m,n+1)): print(i)