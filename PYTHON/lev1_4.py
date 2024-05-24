def check_speed(speed):
    if speed > 100:
        print("Dangerous Speed")
    elif speed >= 81:
        print("Overspeed")
    elif speed >= 61:
        print("Fast Speed")
    elif speed >= 41:
        print("Moderately Fast Speed")
    elif speed >= 31:
        print("That is a good speed")
    elif speed >= 1:
        print("Thoda slow hai speed")
    elif speed == 0:
        print("Gaadi chalu to karo bhai")
    else:
        print("Invalid speed")

# Input from the user
speed = int(input("Enter the vehicle's speed: "))

# Display message based on vehicle's speed
check_speed(speed)
