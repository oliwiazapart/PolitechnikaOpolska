def sortuj(lista):
    for i in range (0,11):
        for j in range (1,10):
            if(lista[j-1] > lista[j]):
                lista[j-1], lista[j] = lista[j], lista[j - 1] 
    return lista

lista = []

from random import seed
from random import randint

seed(1)

for i in range(10):
	wart = randint(0, 100)
	lista.append(wart)
    
print(lista)

print(sortuj(lista))

lista2 = ['kot', 'pies', 'ptak', 'kurczak', 'rybka', 'mysz', 'krowa', 'szczur', 'motyl', 'zebra']

print(lista2)

print(sortuj(lista2))