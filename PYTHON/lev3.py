# Step 1: Define marks in Subjective DHA and CT-1
sub_dha_marks = 35
ct1_marks = 38

# Step 2: Display marks in Subjective DHA and CT-1
print("Subjective DHA marks:", sub_dha_marks)
print("CT-1 marks:", ct1_marks)

# Step 3: Calculate percentage
perc = (sub_dha_marks + ct1_marks) * 100 / 80

# Step 4: Check if percentage is greater than or equal to 80
if perc >= 80:
    print("You can skip CT-2")

# Step 5: Check if percentage is less than 80
elif perc < 80:
    print("You can consider giving CT-2")
