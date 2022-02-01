from graphics import *
from random import randint

win = GraphWin('Okno',700,700)

'''
p1 = Point(100,100)
p2 = Point(200,200)
p3 = Point(300,150)

line1 = Line(p1,p2)
line2 = Line(p2,p3)
line3 = Line(p3,p1)

line1.draw(win)
line2.draw(win)
line3.draw(win)
'''

pktx = []
pkty = []


for i in range(10):
    pktx.append(randint(0, 700))
    pkty.append(randint(0, 700))

for j in range(9):
    line = Line(Point(pktx[j], pkty[j]), Point(pktx[j + 1], pkty[j + 1]))
    line.draw(win)

line = Line(Point(pktx[-1], pkty[-1]), Point(pktx[0], pkty[0]))
line.draw(win)

win.getMouse()
win.close()