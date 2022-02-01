with  open("p.txt") as fo:
    word = input()
    for line in fo:
            if word in line:
                 print(line)