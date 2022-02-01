from graphics import *
from random import randint, choice
from time import sleep

win = GraphWin("Okno", 500, 500)
color = ['pink', 'sky blue', 'peachpuff', 'palegreen']

for i in range(0,50):
    randcolor = choice(color)
    c = Circle(Point(randint(0,500),randint(0,500)), randint(10, 30))
    c.setWidth(5)
    c.setFill(randcolor)
    c.setOutline(randcolor)
    c.draw(win)
    sleep(0.1)

win.getMouse()
win.close()
