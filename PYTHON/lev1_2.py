def display_message(internship_status):
    if internship_status == 'Yes':
        print("You can come in your free period in ETED Lab")
    elif internship_status == 'No':
        print("Come daily after 12:30 in ETED Lab")
    else:
        print("Ye kaun sa status hai?")

# Input from the user
internship_status = input("Enter your internship status (Yes / No): ")

# Display message based on internship status
display_message(internship_status)
