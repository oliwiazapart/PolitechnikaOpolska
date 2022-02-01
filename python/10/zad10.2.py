'''
sl={"Imię": "Anna", "Wiek":30, 5:"Costam", (6,2):32}
print(sl)
sl['dodatki']= "blabla"
print(sl)
del sl[5]
print(sl)
print(list(sl.keys()))
print(list(sl.values()))
'''

l1 = ["Imie", "Nazwisko", "Wiek", "Zwierze"]
l2 = ["Ala", "Kowalska", "10", "kot"]

slownik= {}

for i in range(len(l1)):
        slownik[l1[i]] = l2[i]
        
print(slownik)