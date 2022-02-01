from graphics import *
from random import randint
from time import sleep

win = GraphWin('Okno',300,300)
win.setBackground(color="peachpuff")
ctrl = [(0, -1), (-1, 0), (0, 1), (1, 0)]

p = Point(100, 100)
rand = randint(0, len(ctrl) - 1)

while win.isOpen():
    if randint(1, 5) == 1:
        rand = randint(0, len(ctrl) - 1)
        
    pr = p.clone()
    p.move(ctrl[rand][0] * 5, ctrl[rand][1] * 5)
    line = Line(pr, p)
    line.setFill("sky blue")
    line.draw(win)
    sleep(0.01)
