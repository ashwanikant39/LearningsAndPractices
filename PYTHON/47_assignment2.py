# 1. Python program to generate the prime numbers from 1 to N

# num =int(input("Enter the range: "))
# for n in range(2,num+1):
#     for i in range(2,n):
#         if(n%i==0):
#             break
#     else:
#         print(n)


# 2. Python program to find the roots of a quadratic equation
# import math
# a = float(input("Enter the first coefficient: "))
# b = float(input("Enter the second coefficient: "))
# c = float(input("Enter the third coefficient: "))

# if (a!=0.0):
#     d = (b*b)-(4*a*c)
#     if (d==0.0):
#         print("The roots are real and equal.")
#         r = -b/(2*a)
#         print("The roots are ", r,"and", r)
#     elif(d>0.0):
#         print("The roots are real and distinct.")
#         r1 = (-b+(math.sqrt(d)))/(2*a)
#         r2 = (-b-(math.sqrt(d)))/(2*a)
#         print("The root1 is: ", r1)
#         print("The root2 is: ", r2)
#     else:
#         print("The roots are imaginary.")
#         rp = -b/(2*a)
#         ip = math.sqrt(-d)/(2*a)
#         print("The root1 is: ", rp, "+ i",ip)
#         print("The root2 is: ", rp, "- i",ip)
# else:
#     print("Not a quadratic equation.")


# 3. Python program to find the factorial of a number using recursion

# def fact(n):
#     if n == 1:
#         f = 1
#     else:
#         f = n * fact(n-1)
#     return f


# num = int(input("Enter an integer: "))
# result = fact(num)
# print("The factorial of", num, " is: ", result)


# 4. Python program to display the sum of n numbers using a list
# numbers = []
# num = int(input('How many numbers: '))
# for n in range(num):
#     x = int(input('Enter number '))
#     numbers.append(x)
# print("Sum of numbers in the given list is :", sum(numbers))


# 5. Python program to find the odd numbers in an array
# numbers = [8,3,1,6,2,4,5,9]
# count = 0
# for i in range(len(numbers)):
#     if(numbers[i]%2!=0):
#         count = count+1
# print("The number of odd numbers in the list are: ", count)


# 6. Python program to find the largest number in a list without using built-in functions
# numbers = [3,8,1,7,2,9,5,4]
# big = numbers[0]
# position = 0
# for i in range(len(numbers)):
#     if (numbers[i]>big):
#         big = numbers[i]
#         position = i
# print("The largest element is ",big," which is found at position ",position)


# 7. Python program to insert a number to any position in a list
# numbers = [3,4,1,9,6,2,8]
# print(numbers)
# x = int(input("Enter the number to be inserted: "))
# y = int(input("Enter the position: "))
# numbers.insert(y,x)
# print(numbers)


# 8. Python program to delete an element from a list by index
# numbers = [3,4,1,9,6,2,8]
# print(numbers)
# x = int(input("Enter the position of the element to be deleted: "))
# numbers.pop(x)
# print(numbers)


# 9. Python program to check whether a string is palindrome or not
# def rev(inputString):
#     return inputString[::-1]
# def isPalindrome(inputString):
#     reverseString = rev(inputString)
#     if (inputString == reverseString):
#      return True
#      return False
# s = input("Enter a string: ")
# result = isPalindrome(s)
# if result == 1:
#     print("The string is palindrome")
# else:
#     print("The string is not palindrome")


# 10. Python program to implement matrix addition

# X = [[8,5,1],
#      [9 ,3,2],
#      [4 ,6,3]]

# Y = [[8,5,3],
#      [9,5,7],
#      [9,4,1]]

# result = [[0,0,0],[0,0,0],[0,0,0]]

# for i in range(len(X)):
#     for j in range(len(X[0])):
#         result[i][j] = X[i][j] + Y[i][j]
# for k in result:
#     print(k)


# 11. Python program to check leap year
# year = int(input("Enter a year: "))
# if (year % 4) == 0:
#     if (year % 100) == 0:
#         if (year % 400) == 0:
#             print(year, "is a leap year")
#         else:
#          print(year, "is not a leap year")
#     else:
#         print(year, "is a leap year")
# else:
#     print(year, " is not a leap year")


# 12. Python program to print Fibonacci series using iteration
# a = 0
# b = 1
# n=int(input("Enter the number of terms in the sequence: "))
# print(a,b,end=" ")
# while(n-2):
#     c=a+b
#     a,b = b,c
#     print(c,end=" ")
#     n=n-1


# 13. Python program to print all the items in a dictionary
# phone_book = {
#     'John': ['8592970000', 'john@xyzmail.com'],
#     'Bob': ['7994880000', 'bob@xyzmail.com'],
#     'Tom': ['9749552647', 'tom@xyzmail.com']
# }
# for k, v in phone_book.items():
#     print(k, ":", v)


# 14. Python program to implement a calculator to do basic operations
# def add(x,y):
#     print(x+y)
# def subtract(x,y):
#     print(x-y)
# def multiply(x,y):
#     print(x*y)
# def divide(x,y):
#     print(x/y)


# print("Enter two numbers")
# n1=input()
# n2=input()
# print("Enter the operation +,-,*,/ ")
# op=input()
# if op=='+':
#     add(int(n1),int(n2))
# elif op=='-':
#     subtract(int(n1),int(n2))
# elif op=='*':
#     multiply(int(n1),int(n2))
# elif op=='/':
#     divide(int(n1),int(n2))
# else:
#     print(" Invalid entry ")



# 15. Python program to draw a circle of squares using Turtle
# import turtle
# x = turtle.Turtle()
# def square(angle):
#     x.forward(100)
#     x.right(angle)
#     x.forward(100)
#     x.right(angle)
#     x.forward(100)
#     x.right(angle)
#     x.forward(100)
#     x.right(angle+10)
# for i in range(36):
#     square(90)



# 16. Python program to implement linear search
# numbers = [4,2,7,1,8,3,6]
# f = 0 #flag
# x = int(input("Enter the number to be found out: "))
# for i in range(len(numbers)):
#     if (x==numbers[i]):
#         print("Successful search, the element is found at position", i)
#         f = 1
#         break
# if(f==0):
#     print("Oops! Search unsuccessful")



# 17. Python program to implement binary search
# def binarySearch(numbers, low, high, x):
#     if (high >= low):
#         mid = low + (high - low)//2 #to find mid element
#         if (numbers[mid] == x):
#             return mid
#         elif (numbers[mid] > x):
#             return binarySearch(numbers, low, mid-1, x)
#         else:
#             return binarySearch(numbers, mid+1, high, x)
#     else:
#         return -1


# numbers = [ 1,4,6,7,12,17,25 ] #binary search requires sorted numbers
# x = 50
# result = binarySearch(numbers, 0, len(numbers)-1, x)
# if (result != -1):
#     print("Search successful, element found at position ", result)
# else:
#     print("The given element is not present in the array")