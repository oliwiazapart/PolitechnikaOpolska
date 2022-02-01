def ilerazy(file, char):
    fo = open(file, "r")
    text = fo.read()
    print(text)
    return text.count(char)

print(ilerazy("p.txt", "a"))

