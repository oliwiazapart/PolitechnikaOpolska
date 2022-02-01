fo = open('slang.txt','r')
s = fo.read()

sl={}
spr = 0 
key = ""
value = ""

for i in s:
    if i == ":":
        spr = 1
    elif i == ";":
        sl[key] = value
        value = ""
        key = ""
        spr = 0
    else: 
        if spr == 0:
            key += i
        else:
            value += i
            
print(sl)

