#include <stdio.h>
#include <string.h>

struct student_data
{
    int roll;
    char name[20];
    char branch[30];
    float cgpa;
    int year;
} stddt[20] = {939, "Aditya", "IT", 7.67, 2021,
               932, "Akash", "VOC IT", 7.50, 2021,
               936, "Ankush", "Electric", 8.14, 2023,
               961, "Saurabh", "Mach", 6.3, 2020,
               935, "Ankit", "NDA", 7.45, 2019

};

void name()
{
    char copyName[100];
    char name[100];
    printf("Enter name: ");
    fgets(name, 100, stdin);
    // puts(name);
    strcpy(copyName, name);
    for (int i = 0; i <= 20; i++)
    {
        if (copyName == stddt[i].name)
        {
            printf("hiiii");
        }
    }
}
int main()
{
    name();

    return 0;
}