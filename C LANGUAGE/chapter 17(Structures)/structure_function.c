#include <stdio.h>

struct student
{
    char name[50];
    int roll;
    float cgpa;
} ;
void printinfo(struct student s1);
int main()
{
    struct student s1 = {"Aditya", 2104939, 7.6};
    printinfo(s1);
    return 0;
}
void printinfo(struct student s1)
{
    printf("name= %s\n", s1.name);
    printf("roll= %d\n", s1.roll);
    printf("cgpa= %f\n", s1.cgpa);
}
