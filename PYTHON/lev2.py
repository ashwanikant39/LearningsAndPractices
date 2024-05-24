# Step 1: Define marks in three subjects
h_marks = 85
e_marks = 90
m_marks = 80

# Step 2: Display marks in three subjects
print("Marks in Hindi:", h_marks)
print("Marks in English:", e_marks)
print("Marks in Maths:", m_marks)

# Step 3: Check for max marks in Hindi
if h_marks > e_marks and h_marks > m_marks:
    print("You have got max marks in Hindi")

# Step 4: Check for max marks in English
elif e_marks > h_marks and e_marks > m_marks:
    print("You have got max marks in English")

# Step 5: Check for max marks in Maths
elif m_marks > h_marks and m_marks > e_marks:
    print("You have got max marks in Maths")

# Step 6: If marks are same in all three subjects
else:
    print("Marks are same in all three subjects")
