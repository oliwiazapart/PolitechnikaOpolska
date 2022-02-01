from random import randint

fo = open("liczby.txt", "a")

for j in range(20):
     fo.write(str(randint(0, 100)))
     fo.write(" ")
     
fo.close()
