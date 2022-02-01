from graphics import *
from random import random
from math import sin, cos
from time import sleep

alfa = 0

win = GraphWin('Okno',500,500)
win.setBackground(color="peachpuff")

c = Circle(Point(100, 100), 20)
c.setFill("pink")
c.setOutline("pink")
c.draw(win)

while win.isOpen():
    alfa += random() - 0.6
    c.move(10 * cos(alfa), 5 * sin(alfa))
    sleep(0.01)