print("Zdanie: ")
zdanie = input()
ilosc = []
lista = zdanie.split()

for i in lista:
    print(i, end="\n")
    ilosc.append(i)
print()

print(len(ilosc))