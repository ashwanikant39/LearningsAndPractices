def display_greeting(religion):
    if religion == 'Hindu':
        print("Namaskar")
    elif religion == 'Muslim':
        print("Salaam")
    elif religion == 'Sikh':
        print("Sat Sri Akaal")
    elif religion == 'Christian':
        print("Praise the Lord")
    else:
        print("Unknown religion")

# Input from the user
religion = input("Enter your religion: ")

# Display greeting based on religion
display_greeting(religion)
