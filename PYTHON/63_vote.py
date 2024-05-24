def check_eligibility(age):
    if age>=18:
        print("You are eligible to vote!")
    elif age>=0 and age<18:
        print("You are not eligible to vote!")
    else:
        print("Please Enter the valid age")


#input the age
age=int(input("Enter the age: "))

# call the function and pass the age
check_eligibility(age)
