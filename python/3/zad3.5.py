for i in range(10):
    for j in range(10):
        if(i == 0 or i == 9 or j == 0 or j == 9 or i == 0  + j):
            print("*", end=" ")
        else:
            print(" ", end=" ")
    print()
    
for i in range(10):
    for j in range(10):
        if(i == 0 or i == 9 or j == 0 or j == 9 or i == 0  +  j or i == 9 - j):
            print("*", end=" ")
        else:
            print(" ", end=" ")
    print()