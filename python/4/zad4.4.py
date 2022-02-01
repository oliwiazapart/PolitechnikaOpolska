log2 = 1.0
i = 1.0
j = 1.0
pi = 1.0

while i < 1000:
    i = i + 1
    if i % 2 == 0:
        log2 = log2 - 1/i
    else:
        log2 = log2 + 1/i
    
print(log2) 

while i < 10000:
    i = i + 1
    if i % 2 == 0:
        log2 = log2 - 1/i
    else:
        log2 = log2 + 1/i
    
print(log2) 

while j < 1000:
    j = j + 2
    pi = pi - 1/j
    j = j + 2
    pi = pi + 1/j

print(4*pi) 

while j < 10000:
    j = j + 2
    pi = pi - 1/j
    j = j + 2
    pi = pi + 1/j

print(4*pi) 
        
