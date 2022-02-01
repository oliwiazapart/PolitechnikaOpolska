n=int(input('Podaj n: '))
m=int(input('Podaj m: '))

if m == 0:
    n = 1
    print(n)
    
if m == 1:
    print(n)

i=1
wynik = 1

if m >= 2:
        for i in range (0,m):
            wynik= wynik * n
            i = i + 1
        print(wynik)

    