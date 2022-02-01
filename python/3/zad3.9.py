for i in range(1, 11):
    for j in range(1, 11):
        if (i == 1 or j == 1 ):
            print("{: >2}".format(i * j), end=" ")
        else:
            if i ** j == j ** i:
                print("{: >2}".format("="), end=" ")
            if i ** j > j ** i:
                print("{: >2}".format(">"), end=" ")
            if i ** j < j ** i:
                print("{: >2}".format("<"), end=" ")
    print()