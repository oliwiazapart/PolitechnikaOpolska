def zmien(lista):
    c = lista[0]
    lista [0] = lista[1]
    lista[1] = c
    print(lista)
    return lista
    
lista = [] 

for i in range(0,2):
    el = int(input())
    lista.append(el)
print()

print(lista)

zmien(lista)

print(lista)