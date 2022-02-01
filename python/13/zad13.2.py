from graphics import *
from random import randint

win = GraphWin('Okno',300,300)
color = ['pink', 'sky blue', 'black']

for i in range(1000):
    pt=Point(randint(0,300),randint(0,300))
    pt.setOutline(color[randint(0,2)])
    pt.draw(win)
    
win.getMouse()
win.close()