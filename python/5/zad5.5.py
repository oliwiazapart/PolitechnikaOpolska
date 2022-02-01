l = []


for i in range (100, 151):
    l = l +[i]
    i = i+1

print(l)

for j in range (50, 0, -5):
    if j == 50:
        j = j - 5     
    else:
        del l[j]

print(l)