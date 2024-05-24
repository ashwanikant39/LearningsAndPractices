def display_message(attendance):
    if attendance == 'A':
        print("Sapne me bhi DHA submit mat karna")
    elif attendance == 'P':
        print("Time se DHA submit kar dena")
    else:
        print("Invalid attendance status")

# Input from the user
attendance = input("Enter your attendance status (A / P): ")

# Display message based on attendance status
display_message(attendance)
