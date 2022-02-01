slang = {"Woda":"Water", "Slonce":"Sun", "Ksiezyc":"Moon"}

fo = open("slang.txt", "a")

l=list(slang.values())
l2=list(slang.keys())


for i in range(len(l)):
    s = l[i] + ':' + l2[i] + ';'
    fo.write(s)
    
fo.close()

