def calGrade(averageMarks):
    if averageMarks>=90:
        print("Grade A+")
    elif averageMarks>=80:
        print("Grade A")
    elif averageMarks>70:
        print("grade B")
    elif averageMarks>60:
        print("Grade C")
    elif averageMarks>55:
        print("Grade D")
    else:
        print("Fail")
    
    
#start program from here

#input marks of different Subjects
sub1=float(input("Enter marks of Subject 1: "))
sub2=float(input("Enter marks of Subject 2: "))
sub3=float(input("Enter marks of Subject 3: "))
sub4=float(input("Enter marks of Subject 4: "))
sub5=float(input("Enter marks of Subject 5: "))

#Calculate the average marks of student
averageMarks= (sub1+sub2+sub3+sub4+sub5)/5

#print the average of Marks
print("AVERAGE MARKS: ", averageMarks)

#Call the function to calculate the grade according to average marks  
calGrade(averageMarks)