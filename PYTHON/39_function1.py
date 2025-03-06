def table_reverse(n):
    for i in range(10, 0,-1):
        print(n,'*',i,"= ",i*n)

number=int(input("Enter number: "))
table_reverse(number)