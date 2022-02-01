import math
def roundup(x):
    return int(math.ceil(x / 100.0)) * 100
    
fo = open("pierwsze.txt", "r")
l = []
ok=""
lines = fo.readlines()

for line in lines:
        for s in line:
            if s == " ":
                l.append(ok)
                ok = ""
            else:
                ok = ok + s   
numberl = l[-1]
print(numberl)

fo.close()

fo = open("pierwsze.txt", "a")
numer = int(numberl)
numer2 = roundup(numer)
while numer <= numer2 + 100:
    licz = 0
    i = 2
    
    while i <= numer//2:
        if numer % i == 0:
            licz = licz + 1
        i =  i + 1
    
    if licz == 0 and numer != 1:
        fo.write(str(numer))
        fo.write(" ")
    numer = numer + 1
    
fo.close()