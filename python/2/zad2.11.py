n=int(input('Podaj n: '))

pierw= 0

if n == 1 or n == 0:
    print ("Ani złożona, ani pierwsza")
    
else:  
    if n == 2:
        pierw = 0
    
    for i in range(2, n):
        if n % i == 0:
            pierw = pierw + 1
    
    if pierw == 0:
        print("Liczba pierwsza")
    else:
        print("Liczba złożona")
   
