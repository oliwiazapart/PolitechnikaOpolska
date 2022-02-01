f=float(input('Podaj liczbę f: '))
g=float(input('Podaj liczbę g: '))
  

flicz=str(f)
glicz=str(g)

flist=flicz.split(".", 1)
glist=glicz.split(".", 1)

print(glist[0],".",flist[1])
print(flist[0],".",glist[1])
