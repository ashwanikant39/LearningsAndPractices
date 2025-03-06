number = int(input("Enter a number: "))
if number < 1: #check number is greater than 1 or not
    print("Please enter a positive integer greater than 0.")
else:
    total_sum = 0 #initialization the sum with 0
    for i in range(1, number + 1):   #use loop 1 to that number
        total_sum += i  #add that number in total sum(every time)
    
    #after loop, print total sum
    print("The sum of all numbers from 1 to", number, "is:", total_sum)
