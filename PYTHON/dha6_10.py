input_string = input("Enter a string: ")

reversed_string = "" #initialization the empty string
for char in input_string:
    reversed_string = char + reversed_string  #add every character before that string

print("Reversed string:", reversed_string)
