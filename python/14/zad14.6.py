from graphics import *
from math import sin, cos
from time import sleep

alfa = 0
r = 50
p1 = Point(100, 100)
p2 = Point(150, 100)

win = GraphWin('Okno',300,300)
win.setBackground(color="peachpuff")

c = Circle(p1, 20)
c.setFill("pink")
c.setOutline("pink")
c.draw(win)

c2 = Circle(p2, 20)
c2.setFill("sky blue")
c2.setOutline("sky blue")
c2.draw(win)

while win.isOpen():
    p = [c.getCenter(), c2.getCenter()]
    c2.move(p[0].x + cos(alfa) * r - p[1].x, p[0].y + sin(alfa) *
              r - p[1].y)
    alfa += 0.05
    sleep(0.01)
