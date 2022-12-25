n= list(input("Enter the number"))
n.remove(".")
n = [int(x) for x in n]
s = sorted(set(n))
print(s)