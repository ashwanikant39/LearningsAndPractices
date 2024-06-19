#include <stdio.h>
#include <string.h>

struct student_data
{
    int roll;
    char name[20];
    char branch[30];
    float cgpa;
    int year;
} stddt[20] = {2104939, "Aditya", "IT", 7.67, 2021,
               2104932, "Akash", "VOC IT", 7.50, 2021,
               2104936, "Ankush", "Electric", 8.14, 2023,
               2104961, "Saurabh", "Mach", 6.3, 2020,
               2104935, "Ankit", "NDA", 7.45, 2019};

void rollno()
{
    int rollno, i;
    printf("Enter roll no: ");
    scanf("%d", &rollno);
    printf("\n");
    for (i = 0; i <= 20; i++)
    {
        if (stddt[i].roll == rollno)
        {
            printf("Roll no.- %d\n", stddt[i].roll);
            printf("Name- %s\n", stddt[i].name);
            printf("Branch- %s\n", stddt[i].branch);
            printf("CGPA- %f\n", stddt[i].cgpa);
            printf("Year of joining- %d\n", stddt[i].year);
        }
    }
}

void name(char string[100])
{
    int i;
    // puts(name);
    for (i = 0; i <= 20; i++)
    {

        if (stddt[i].name == string)
        {
            printf("Roll no- %d\n", stddt[i].roll);
            printf("Name- %s\n", stddt[i].name);
            printf("Banch- %s\n", stddt[i].branch);
            printf("CGPA- %f\n", stddt[i].cgpa);
            printf("Year of joining- %d\n", stddt[i].year);
        }
    }
}
void yoj()
{
    int year, i;
    printf("Enter year: ");
    scanf("%d", &year);
    printf("\n");
    for (i = 0; i <= 20; i++)
    {
        if (stddt[i].year == year)
        {
            printf("Roll no %d\n", stddt[i].roll);
            printf("Name- %s\n", stddt[i].name);
            printf("Branch- %s\n", stddt[i].branch);
            printf("CGPA- %f\n", stddt[i].cgpa);
            printf("Year of joining- %d\n", stddt[i].year);
            printf("\n");
        }
    }
}
int main()

{
    int choice;
    char string[100];
    printf("\n---You can Search by roll.no, name or Year of joining---\n Enter '1' for search by roll\n Enter '2' for search by Name\n Enter '3' for search by Year of joing \n");
    printf("Enter your choice: ");
    scanf("%d", &choice);
    switch (choice)
    {
    case 1:
        rollno();
        break;
    case 2:
        printf("Enter name: ");
        scanf("%s", string);
        name(string);
        break;
    case 3:
        yoj();
        break;
    }

    return 0;
}