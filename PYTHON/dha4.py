# Accept a year from the user
year = int(input("Enter a year: "))

# Check if the year is a leap year
#We check if the year is divisible by 4 and not divisible by 100, or if it is divisible by 400. If any of these conditions are true, the year is a leap year.
if (year % 4 == 0 and year % 100 != 0) or (year % 400 == 0):
    print(year, "is a leap year.")
else:
    print(year, "is not a leap year.")
