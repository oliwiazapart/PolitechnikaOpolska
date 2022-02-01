for i in range(10):
    for j in range(10):
        if (i < j  or i == 0  + j):
            print("*", end=" ")
        else:
            print(" ", end=" ")
    print()

print()

for i in range(10):
    for j in range(10):
        if (i > j  or i == 0  + j):
            print("*", end=" ")
        else:
            print(" ", end=" ")
    print()
    
print()
    
for i in range(10):
    for j in range(10):
        if (i < 9 - j  or i == 9 - j):
            print("*", end=" ")
        else:
            print(" ", end=" ")
    print()
    
print()

for i in range(10):
    for j in range(10):
        if (i > 9 - j  or i == 9 - j):
            print("*", end=" ")
        else:
            print(" ", end=" ")
    print()