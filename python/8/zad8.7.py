fo = open("p.txt", "r")

fo2 = open("p2.txt", "a")

for i in fo.read():
    if i == " ":
        fo2.write("*")
    else:
        fo2.write(i.upper())
    
fo.close()
fo2.close()