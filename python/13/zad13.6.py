from graphics import *
from random import randint, choice
from math import sin, cos, pi

win = GraphWin('Okno',700,700)
n = int(input("n =  "))

pkt=[]

for i in range(n):
    pktx=250+250*cos(2*pi*i/n)
    pkty=250+250*sin(2*pi*i/n)
    pkt.append(Point(pktx,pkty))

for j in range(n):
     l=Line(pkt[j%n],pkt[(j+1)%n])
     l.draw(win)
     
win.getMouse()
win.close()
