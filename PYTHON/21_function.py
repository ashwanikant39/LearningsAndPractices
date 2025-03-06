def checkMax(a, b):
    if (a > b):
        print(a, "is greater")
    elif (b > a):
        print(b, "is greater")
    else:
        print("Both are equal")


a = int(input("Enter first number: "))
b = int(input("Enter second number: "))

checkMax(a, b)
