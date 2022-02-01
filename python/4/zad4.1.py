for i in "To jest zdanie":
    print(i, end="*")
    
print()

print("Wprowadź zdanie: ")
zdanie = input()
ilosc = []


for i in zdanie:
    print(i, end=" ")
    ilosc.append(i)
print()

print(len(ilosc))