from random import randint
x1 = randint(0,49)
y1 = randint(0,49)
x2 = randint(0,49)
y2 = randint(0,49)

print("Pkt 1 - x1:", x1, "i y1 =", y1)
print("Pkt 2 - x2:", x2, "i y2 =", y2)

fo = open("gwiazdki.txt", "a")

if x1 < x2:
    for i in range(50): 
        for j in range(50): 
            if x1<=j<=x2 and abs(((y2-y1)/(x2-x1)*(j-x1)+y1)-i)<0.5:
                fo.write("*")
            else: 
                fo.write(" ")
        fo.write("\n")

if x1 > x2:     
    for i in range(50): 
        for j in range(50): 
            if x2<=j<=x1 and abs(((y1-y2)/(x1-x2)*(j-x2)+y2)-i)<0.5:
                fo.write("*")
            else: 
                fo.write(" ")
        fo.write("\n")
        

if x1 == x2:
    for i in range(50): 
        for j in range(50): 
            if x1 == j and (min(y1,y2)<=i<=max(y1,y2)):
                fo.write("*")
            else: 
                fo.write(" ")
        fo.write("\n")
    
fo.close()