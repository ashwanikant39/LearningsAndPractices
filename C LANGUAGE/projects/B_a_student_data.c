#include <stdio.h>
struct studata
{
    int roll;
    char name[100];
    char depart[100];
    char course[100];
    int yoj;
} nos[450] = {2104939, "ashwani", "polytechnic", "IT", 2021,
              2104932, "akash", "b tech", "CS", 2022,
              2104942, "ashu", "diploma", "computer science", 2020,
              2104936, "Ankush raj", "diploma", "electric", 2021,
              2104935, "Ankit", "b.sc", "electronics", 2024};

void student_in_year(int year)
{
    int i;
    printf("\n\n\t\tstudent in %d\n", year);
    for (i = 0; i <= 450; i++)
    {
        if (nos[i].yoj == year)
        {
            printf("\nRoll Number : %d", nos[i].roll);
            printf("\nName : %s", nos[i].name);
            printf("\nDepartment : %s", nos[i].depart);
            printf("\nCourse : %s\n", nos[i].course);
            // printf("\nCourse : %s\n", nos[i].course);
        }
    }
}
void student_by_rollno()
{
    int roll_no, i;
    printf("Enter the roll number: ");
    scanf("%d", &roll_no);
    for (i = 0; i <= 450; i++)
    {
        if (nos[i].roll == roll_no)
        {
            printf("roll no %d's data\n", roll_no);
            printf("\nName : %s", nos[i].name);
            printf("\nDepartment : %s", nos[i].depart);
            printf("\nCourse : %s", nos[i].course);
            printf("\nYera of joining : %d\n\n", nos[i].yoj);
            // printf("\nYera of joining : %d\n\n", nos[i].yoj);
        }
    }
}

int main()
{
    int year, roll_no, choice;
    printf("\n\t\t(You can search student by their Year of joining, Roll no.)\n\t---Enter the choice--- \n 1 for search by year\n 2 for searchh by roll num: ");
    scanf("%d", &choice);
    switch (choice)
    {
    case 1:
        printf("\n\nEnter the year: ");
        scanf("%d", &year);
        student_in_year(year);
        break;
    case 2:
        student_by_rollno();
        break;
    }
    return 0;
}