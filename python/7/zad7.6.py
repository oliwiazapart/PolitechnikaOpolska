def sortuj(lista):
    for i in range(len(lista)-1):
        for j in range(len(lista)-1):
            if len(lista[j]) > len(lista[j+1]):
                c=lista[j]
                lista[j]=lista[j+1]
                lista[j+1]=c
                
def sortujalfa(lista):
    for i in range (0,len(lista)+1):
        for j in range (1,len(lista)):
            if(lista[j-1] > lista[j]):
                lista[j-1], lista[j] = lista[j], lista[j - 1] 
    return lista
                              
zdanie = input("Wprowadz zdanie: ")
print("Wprowadzone zdanie: ", zdanie)

l = zdanie.split()

lista = []

zdaniel = ''

for i in zdanie:
    if i == ' ':
        lista.append(zdaniel)
        zdaniel = ''
    else:
        zdaniel = zdaniel + i
        
lista.append(zdaniel)
print(lista)

sortuj(lista)
print(lista)

sortujalfa(lista)
print(lista)
