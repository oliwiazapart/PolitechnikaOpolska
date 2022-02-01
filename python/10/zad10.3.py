def bezpowt(sl):
    l=list(sl.values())
    for i in range(len(l)):
        if len(l) == len(set(l)):
            return 1
        else:
            return 0
        
    
sl1 = {"A":1,"B":2,"C":4,"D":4}
sl2 = {"A":1,"B":2,"C":3,"D":4}

print(bezpowt(sl1))
print(bezpowt(sl2))