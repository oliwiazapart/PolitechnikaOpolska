from graphics import *

win = GraphWin('Okno',600,600)

p1 = Point(100,100)
p2 = Point(300,200)

p3 = Point(350,300)
p4 = Point(500,250)


r = Rectangle(p1,p2)
r.setOutline("palegreen")
r.setWidth(3)
r.setFill("sky blue")
r.draw(win)


o = Oval(p3,p4)
o.setOutline("peachpuff")
o.setWidth(3)
o.setFill("pink")
o.draw(win)


win.getMouse()
win.close()