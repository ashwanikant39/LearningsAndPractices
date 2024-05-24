# Initialize an empty list to store the states' names
states = []

# Accept 6 states' names from the user
for i in range(6):
    state = input("Enter indian state name {}: ".format(i+1))
    states.append(state)

# Print all the states' names
print("States' names:")
for state in states:
    print(state)
