from math import pi 

l = []

licz = "%.49f" % pi

l = [int(i) for i in licz if i != "."]
print(l)