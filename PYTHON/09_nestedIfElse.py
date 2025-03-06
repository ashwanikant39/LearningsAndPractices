num = int(input("Enter number: "))
# num = 20

if (num >= 0 and num <= 20):
    if (num >= 10 and num < 15):
        print("number 10- 14")
    elif (num == 15):
        print("number is 15")
    elif (num >= 0 and num < 10):
        print("Number less than 10")
    else:
        print("Number is 16-20")

elif (num > 20 and num <= 35):
    if (num > 20 and num < 30):
        print("number 21-29")
    elif (num == 30):
        print("Number is 30")
    else:
        print("Number is 31-35")

else:
    print("Number greater than 35")
