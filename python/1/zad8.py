R=int(input('Podaj rok: '))

if(R%400 == 0):
    print("przestępny")

elif(R%100 == 0):
    print("nieprzestępny")
    
elif(R%4 == 0):
    print("przestępny")

else:
    print("nieprzestępny")
