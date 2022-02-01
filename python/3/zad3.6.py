for i in range(10):
    for j in range(10):
        if(j % 2 == 0 and i % 2 == 0 or j % 2 != 0 and i % 2 != 0):
            print("*", end=" ")
        else:
            print(" ", end=" ")
    print()