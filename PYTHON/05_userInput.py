# take input by user

a = input("Enter your first name: ")  # It take input as STRING
print("Your name is", a, "\n")

b = input("Enter your second name: ")
print("Your second name is", b, "\n")

print("Your full name is: ", a+b)


# input take input as  string but we can typecaste it

x = input("Enter num1: ")  # 5
y = input("Enter num2: ")  # 4
print(x+y)  # by default it add as a string --> output:54


# Add after typecasting
print("Add after typecasting: ", float(x)+int(y))
