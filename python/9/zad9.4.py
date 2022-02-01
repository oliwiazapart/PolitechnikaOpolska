fo = open("pierwsze.txt", "a")
numer = 1

while numer <= 100:
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