fo = open("p.txt", "r")

while 1:
    s = fo.read(3)
    if s == "":
        break
    print(s, end=" ")

