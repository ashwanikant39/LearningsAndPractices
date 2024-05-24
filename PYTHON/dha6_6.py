print("Numbers divisible by 3 but not by 5:")
for number in range(1, 101):
    if number % 3 == 0 and number % 5 != 0:
        print(number)
