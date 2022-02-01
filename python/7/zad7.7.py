def sortujalfa(lista):
    for i in range (0,len(lista)+1):
        for j in range (1,len(lista)):
            if(lista[j-1] > lista[j]):
                lista[j-1], lista[j] = lista[j], lista[j - 1]
            if(lista[j-1] == lista[j]):
                lista[j-1], lista[j] = lista[j], lista[j - 1]
    return lista

from random import randint

lista = []

for i in range(100):
    randel = randint(3,8)
    el = ''
    for j in range(randel):
        funchrel = chr(randint(97,122))
        el = el + funchrel
    lista.append(el)
    
print(lista)
sortujalfa(lista)
print(lista)

lista2 = []

for ii in range(100):
    randel = randint(3,8)
    el = ''
    for jj in range(randel):
        funchrel = chr(randint(97,122))
        el = el + funchrel
    lista2.append(el)
    
print(lista2)
sortujalfa(lista2)
print(lista2)