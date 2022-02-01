l = []
l2 =[]
liczba = 1
zmiana = 0

for i in range (1, 11):
    liczba = i ** 2
    l = l +[liczba]
    i = i+1
    
print(l)

for i in l:
    zmiana = i * (-1)
    l2 = l2 +[zmiana]
    i = i+1
    
print(l2)
    