import random
wybor= [" ", " ", " ", " ", "*"]
fo = open("gwiazdki.txt", "a")

for i in range(50):
    for j in range(50):
        fo.write(str(random.choice(wybor))+ " ")
    fo.write("\n")
     
fo.close()
