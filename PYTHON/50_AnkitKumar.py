# def factorial(n):
#     if n == 0:
#         return 1
#     fact = 1
#     for i in range(1, n + 1):
#         fact *= i
#     return fact

# # Taking input from user
# num = int(input("Enter a number: "))

# # Checking if the number is negative
# if num < 0:
#     print("Factorial cannot be found for negative numbers")
# else:
#     print("Factorial of", num, "is", factorial(num)) #call the function

# Function to print Fibonacci sequence up to n terms

# def fibonacci(n):
#     # Initialize first two terms
#     a, b = 0, 1
#     count = 0

#     # Check if the number of terms is valid
#     if n <= 0:
#         print("Please enter a positive integer")
#     elif n == 1:
#         print("Fibonacci sequence up to", n, "terms:")
#         print(a)
#     else:
#         print("Fibonacci sequence up to", n, "terms:")
#         while count < n:
#             print(a, end="  ")
#             nth = a + b
#             # Update values for the next iteration
#             a = b
#             b = nth
#             count += 1

# # Take input from the user
# terms = int(input("Enter the number of terms: "))

# # Call the function to print Fibonacci sequence
# fibonacci(terms)

# Program to check if a number is prime or not
# num = int(input("Enter the number: "))

# # To take input from the user
# #num = int(input("Enter a number: "))

# # define a flag variable
# flag = False

# if num == 1:
#     print(num, "is not a prime number")
# elif num > 1:
#     # check for factors
#     for i in range(2, num):
#         if (num % i) == 0:
#             # if factor is found, set flag to True
#             flag = True
#             # break out of loop
#             break

#     # check if flag is True
#     if flag:
#         print(num, "is not a prime number")
#     else:
#         print(num, "is a prime number")


# Python3 program to display Prime numbers till N

#function to check if a given number is prime
def isPrime(n):
#since 0 and 1 is not prime return false.
	if(n==1 or n==0): return False

#Run a loop from 2 to n-1
	for i in range(2,n):
	#if the number is divisible by i, then n is not a prime number.
		if(n%i==0):
			return False

#otherwise, n is prime number.
	return True



# Driver code
N = 100
#check for every number from 1 to N
for i in range(1,N+1):
#check if current number is prime
	if(isPrime(i)):
		print(i,end=" ")

