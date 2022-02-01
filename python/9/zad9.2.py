fo = open("liczby.txt", "r")

l = []
ok = ""
lines = fo.readlines()


while 1:
    h = fo.read()
    for line in lines:
        for s in line:
            if s == " ":
                l.append(ok)
                ok = ""
            else:
                ok = ok + s   
    if h == "":
        break
print(l)