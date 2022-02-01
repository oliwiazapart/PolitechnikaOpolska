n=int(input('Podaj n: '))

pierwiastek = 1
kwadrat = 1
znajdz = False

while kwadrat <= n:
    if kwadrat == n:
        znajdz = True
        break
    pierwiastek = pierwiastek + 1 
    kwadrat = pierwiastek * pierwiastek
    
if znajdz:
    print("pierwiastek istnieje, liczba naturalna: ", pierwiastek)
    
else:
    print("nie jest kwadratem żadnej liczby naturalnej")
