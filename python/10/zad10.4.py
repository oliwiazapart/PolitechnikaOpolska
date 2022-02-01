def odwr(sl):
    l=list(sl.values())
    l2=list(sl.keys())
    for i in range(len(l)):
        if len(l) == len(set(l)):
            sl2 = {l[j] : l2[j] for j in range(len(l2))}
            return sl2
            
        else:
            print("Error!")
            return 0
            
                
sl = {"A":1,"B":2,"C":3,"D":4}
sl1 = {"A":1,"B":2,"C":4,"D":4}
slang = {"Woda":"Water", "Slonce":"Sun", "Ksiezyc":"Moon"}

print(odwr(sl))
print(odwr(sl1))
print(odwr(slang))