# 1. Python program to check whether the given number is even or not.
# number = input("Enter a number: ")
# x = int(number)%2
# if x == 0:
#     print("The number is Even.")
# else:
#     print("The number is Odd.")


# 2. Python program to convert the temperature in degree centigrade to Fahrenheit
# c = input("Enter temperature in Centigrade: ")
# f = (9*(int(c))/5)+32
# print("Temperature in Fahrenheit is: ", f)


# 3. Python program to find the area of a triangle whose sides are given
# import math
# a = float(input("Enter the length of side a: "))
# b = float(input("Enter the length of side b: "))
# c = float(input("Enter the length of side c: "))
# s = (a+b+c)/2
# area = math.sqrt(s*(s-a)*(s-b)*(s-c))
# print("Area of the triangle is: ", area)


# 4. Python program to find out the average of a set of integers
# count = int(input("Enter the count of numbers: "))
# i = 0
# sum = 0
# for i in range(count):

#     x = int(input("Enter an integer: "))
#     sum = sum + x
# avg = sum/count
# print("The average is: ", avg)


# 5. Python program to find the product of a set of real numbers
# i = 0
# product = 1
# count = int(input("Enter the number of real numbers: "))
# for i in range(count):
#     x = float(input("Enter a real number: "))
#     product = product * x
# print("The product of the numbers is: ", product)


# 6. Python program to find the circumference and area of a circle with a given radius
# import math
# r = float(input("Input the radius of the circle: "))
# c = 2 * math.pi * r
# area = math.pi * r * r
# print("The circumference of the circle is: ", c)
# print("The area of the circle is: ", area)


# 7. Python program to check whether the given integer is a multiple of 5
# number = int(input("Enter an integer: "))
# if(number%5==0):
#     print(number, "is a multile of 5")
# else:
#     print(number, "is not a multiple of 5")


# 8. Python program to check whether the given integer is a multiple of both 5 and 7
# number = int(input("Enter an integer: "))
# if((number%5==0)and(number%7==0)):
#     print(number, "is a multiple of both 5 and 7")
# else:
#     print(number, "is not a multiple of both 5 and 7")



# 9. Python program to find the average of 10 numbers using while loop
# count = 0
# sum = 0.0
# while(count<10):
#     number = float(input("Enter a real number: "))
#     count=count+1
#     sum = sum+number
# avg = sum/10
# print("Average is :",avg)


# 10. Python program to display the given integer in a reverse manner
# number = int(input("Enter a positive integer: "))
# rev = 0
# while(number!=0):
#     digit = number%10
#     rev = (rev*10)+digit
#     number = number//10
# print(rev)


# 11. Python program to find the geometric mean of n numbers
# c = 0
# p = 1.0
# count = int(input("Enter the number of values: "))
# while(c<count):
#     x = float(input("Enter a real number: "))
#     c = c+1
#     p = p * x
# gm = pow(p,1.0/count)
# print("The geometric mean is: ",gm)


# 12. Python program to find the sum of the digits of an integer using a while loop
# sum = 0
# number = int(input("Enter an integer: "))
# while(number!=0):
#     digit = number%10
#     sum = sum+digit
#     number = number//10
# print("Sum of digits is: ", sum)



# 13. Python program to display all the multiples of 3 within the range 10 to 50
# for i in range(10,50):
#     if (i%3==0):
#         print(i)


# 14. Python program to display all integers within the range 100-200 whose sum of
# digits is an even number

# for i in range(100,200):
#     num = i
#     sum = 0
#     while(num!=0):
#         digit = num%10
#         sum = sum + digit
#         num = num//10
#     # print(sum)
#     if(sum%2==0):
#         print(i)




# 15. Python program to check whether the given integer is a prime number or not
num = int(input("Enter an integer greater than 1: "))
isprime = 1 #assuming that num is prime
for i in range(2,num):
    if (num%i==0):
      isprime = 0
      break
if(isprime==1):
    print(num, "is a prime number")
else:
    print(num, "is not a prime number")