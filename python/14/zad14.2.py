from graphics import *

win = GraphWin('Okno',600,600)
win.setBackground(color="peachpuff")

c = Circle(Point(100, 100), 20)
c.setFill("pink")
c.setOutline("pink")
c.draw(win)

ctrl = {'w' : (0,-20), 's': (0, 20), 'a': (-20,0), 'd': (20, 0)}

while win.isOpen():
    k= win.getKey()
    if k in "wsad": 
        c.move(ctrl[k][0], ctrl[k][1])
    elif k == 'q':
        win.close()


