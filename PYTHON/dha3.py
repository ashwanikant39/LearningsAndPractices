# Accept a character from the user
character = input("Enter a character: ")

# Convert the character to lowercase to handle both cases (uppercase and lowercase)
character = character.lower()

# Check if the character is a vowel
if character in ['a', 'e', 'i', 'o', 'u']:
    print("The character", character, "is a vowel.")
else:
    print("The character", character, "is not a vowel.")
