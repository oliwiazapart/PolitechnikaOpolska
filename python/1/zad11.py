i=int(input('Podaj i: '))
j=int(input('Podaj j: '))

if(i**j > j**i):
    print(i, "do", j, "równe", i**j, "jest większe od", j, "do", i, "równe", j**i)
else:
    print(j, "do", i, "równe", j**i, "jest większe od", i, "do", j, "równe", i**j)
