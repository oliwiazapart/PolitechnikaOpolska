from graphics import *
from time import sleep

win = GraphWin('Okno',600,600)

o = Oval(Point(win.getWidth() / 4, 40), Point(win.getWidth(), win.getHeight() / 5))
o.setFill("pink")
o.draw(win)


c = Circle(Point(win.getWidth() / 5, win.getHeight() / 3), win.getHeight() / 4)
c.setFill("peachpuff")
c.draw(win)

p1 = Point(500,500)
p2 = Point(400,280)

r = Rectangle(p1, p2)
r.setFill("sky blue")
r.draw(win)

while c.getCenter().x < o.getCenter().x:
    c.move(2, 0)
    sleep(0.01)

win.getMouse()
win.close()

