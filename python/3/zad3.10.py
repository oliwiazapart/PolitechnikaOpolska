for i in range(10):
    for j in range(10):
        if((j == 0 or j == 9) and (i!=0 and i!=9)) :
            print("*",end="")   
        elif( ((i==0 or i==9) and (j>0 and j<9))):
            print("*",end="")
        elif(i == 0 or i == 9):
            print(end=" ") 
        else:
            print("*",end="")
    print() 
    
print() 

for i in range(10):
    for j in range(10):
        if((j == 0 or j == 9) and (i!=0 and i!=9)) :
            print("*",end="")   
        elif( ((i==0 or i==9) and (j>0 and j<9))):
            print("*",end="")
        else:
            print(end=" ")  
    print() 