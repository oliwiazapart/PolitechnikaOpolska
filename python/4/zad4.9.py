a = -1
b = 0


for i in range(100):
    c = (a+b)/2
    if (pow(c,5) + c + 1) * (pow(a,5) + a + 1) > 0:
        a = c
    else:
        b = c
        
print(c)
print(pow(c,5) + c + 1)