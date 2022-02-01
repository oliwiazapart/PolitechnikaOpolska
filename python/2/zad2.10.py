n=int(input('Podaj n: '))

dzielniki=[n]

resz= int(n/2) + 1

for i in range (1, resz):
    if n % i == 0:
        dzielniki.append(i)
        
print("Wszystkie dzielniki liczby", n, ": ")
print(len(dzielniki))
