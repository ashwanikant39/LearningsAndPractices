# Q-10
# num = int(input("Enter the number: "))

# num == True
# i = 2
# while (i < num):
#     if (num % i == 0):
#         num = False
#         break
#     i = i+1
# if (num):
#     print("Number is prime")
# else:
#     print("Number is not prime")

# Q-11
# sum=0
# num=int(input("Enter the number: "))
# while(num!=0):
#     rem=num%10
#     sum=sum+rem
#     num=num//10
# print(sum)

# Q-12
# a=1
# num=int(input("enter no:"))
# while(num!=0):
#     rem =num%10
#     a=a*rem
#     num=num//10
# print(a)


# Q-13
# num=int(input("ENter the number for inverse: "))
# while(num!=0):
#     digit=num%10
#     print(digit,end="")
#     num//=10

# Q-14
# num = int(input("Enter number: "))

# while (num != 0):
#     rem = num % 10
#     match rem:
#         case 1:
#             print("One",end=" ")
#         case 1:
#             print("One",end=" ")
#         case 2:
#             print("two",end=" ")
#         case 3:
#             print("three",end=" ")
#         case 4:
#             print("four",end=" ")
#         case 5:
#             print("five",end=" ")
#         case 6:
#             print("six",end=" ")
#         case 7:
#             print("seven",end=" ")
#         case 8:
#             print("eight",end=" ")
#         case 9:
#             print("nine",end=" ")
#         case 0:
#             print("zero",end=" ")
#     num = num//10


# Q-15

# num=int(input("Enter the number for series: "))
# i=0
# a,b=0,1
# print(a,b,end=" ")
# while(i<num):
#     c=a+b
#     print(c,end=" ")
#     a,b=b,c
#     i+=1





# n=5
# for i in range(n, 0,-1):
#     for j in range(1, n+1):
#         if(j<i):
#             print(" ",end="")
#         else:
#             print("*",end="")
#     print()


# for i in range(1,n+1):
#     for j in range(1, i+1):
#         print("*",end="")
#     print()


# short list
# list1=[122,1,2,56,78]
# list1.sort()
# print(list1)

# Q-17
# digitSum = 0
# num = int(input("Enter the number: "))
# num1 = num  # for copy original number
# while (num != 0):
#     digit = num % 10
#     digitSum = digitSum+(digit**3)
#     num = num//10
# if (digitSum == num1):
#     print("Yes")
# else:
#     print("NO")

# Q-18
# def fact(n):
#     fact = 1
#     for i in range(1, n+1):
#         fact = fact*i
#     return fact

# ans = 0
# n = int(input("Enter n: "))

# for j in range(1, n+1):
#     ans = ans+(1/fact(j))
# print(ans)


# Q-19
# sum = 0
# count = 1
# range1 = int(input("Enter the range till you want enter: "))
# while (range1):
#     print("Enter your", count, "number: ", end="")
#     num = int(input())
#     sum += num
#     range1 -= 1
#     count += 1
# print("Your total sum= ", sum)

# Q-20
# num=True
# sum=0
# while(num!=0):
#     num=int(input("Enter number: "))
#     sum+=num
# print("Total sum= ",sum)

# Q-21 with while loop
# num1 = int(input("Enter the first number: "))
# num2 = int(input("Enter the second number: "))
# i = num1
# while (True):
#     if (num1 % i == 0 and num2 % i == 0):
#         print("H.C.F= ", i)
#         break
#     i -= 1

# Q-21 with for loop
# num1 = int(input("Enter the number: "))
# num2 = int(input("Enter the number: "))
# HCF=1
# for i in range(1,num1 or num2, 1):
#     if(num1%i==0 and num2%i==0):
#         HCF=i
# print("H.C.F= ",HCF)

# # Q-28
# startingNum=int(input("Enter starting number: "))
# endingNum=int(input("Enter ending number: "))
# evenSum=0
# oddSum=0
# while(startingNum<=endingNum):
#     if(startingNum%2==0):
#         evenSum+=startingNum
#     elif(startingNum%2!=0):
#         oddSum+=startingNum
#     startingNum+=1
# print("\nSum of odd num is= ",oddSum)
# print("Sum of even number =",evenSum)


# Q-29
# startingNum=100
# endingNum=500
# while(startingNum<=endingNum):
#     if(startingNum%13==0 and startingNum%3!=0):
#         print(startingNum,end=" ")
#     startingNum+=1

# Q-30
# n=int(input("Enter n: "))
# i="2"
# while(n):
#     print(i,end="  ")
#     i=i+"2"
#     n-=1

# Q-31
# n=int(input("Enter n:"))
# i=1
# while(i<n):
#     print(i,"^2= ",i**2)
#     i+=1

# Q=32
# def fact(n):
#     fact1 = 1
#     i = 1
#     while (i <= n):
#         fact1 = i*fact1
#         i += 1
#     return fact1


# def toPower(x, n):
#     return x**n

# # print(fact(7))
# # print(toPower(5,5))


# x = int(input("Enter x: "))
# n = int(input("Enter n: "))
# i = 1
# finalSum = 1.0
# while (i <= n):
#     finalSum = finalSum+(float(toPower(x, i))/float(fact(i)))
#     i += 1
# print("Final sum= ", finalSum)


# Q-34
# n=int(input("Enter n: "))
# i=1
# sum1=0
# while(i<=n):
#     sum1=sum1+i**3
#     print(i**3)
#     i+=1
# print("final sum=",sum1)

# Q-35
# n=int(input("Enter n: "))
# sum1=0
# x=2
# i=1
# while(i<=n):
#     sum1+=i
#     print(i)
#     i*=x
#     x+=1
# print("Final sum=", sum1)


# Q-36

# n=int(input("Enter n: "))
# sum1=1
# i=2
# while(i<=n):
#     if(i%2==0):
#         sum1=sum1+(i**2)
#     elif(i%2!=0):
#         sum1=sum1-(i**2)
#     i+=1
# print("final sum= ", sum1)

# Q-37
# n="PYTHON"
# print(len(n))
# i=0
# while(n):
#     print(n[i])
#     i+=1

# Q-38
# n=[23,45,32,22,46,33,71,90]
# i=0
# while(i<len(n)):
#     if(n[i]%2==0):
#             print(n[i])
#     i+=1

# Q-39 with for loop
# print("\nWith for loop")
# num = int(input("Enter number: "))
# j = 2
# for i in range(1, num+1):
#     if (num % j == 0):
#         print(j)
#         num //= j
#     elif (num % j != 0):
#         j += 1

# # Q-39 with while loop
# print("\nWith while loop   ")
# num = int(input("Enter number: "))
# i = 2
# print("Factor of", num, "\n")
# while (i <= num):
#     if (num % i == 0):
#         print(i, "|", num)
#         print("--|-------")
#         num = num//i
#     elif (num % i != 0):
#         i += 1
# print("  |",num)





# Q-40
# i=1
# j=49
# while(i<=j):
#     while(j>=1):
#         print(i,"--",j)
#         j-=1
#         i+=1

# Q-41 LCM with for loop
# num1=15
# num2=70
# range1=True

# for i in range(num1,99999999,1):
#     if(i%num1==0 and i%num2==0):
#         print("L.C.M of",num1,"&", num2,"is",i)
#         break

# LCM with for loop
# num1 = 7
# num2 = 15
# i = num1
# while (True):
#     if (i % num1 == 0 and i % num2 == 0):
#         print("L.C.M= ", i)
#         break
#     i += 1

