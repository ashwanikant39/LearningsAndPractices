#include <stdio.h>
#include <string.h>

struct student
{
   int roll;
   float cgpa;
   char name[100];
}std;

int main()
{
   struct std s1 = {1664, 9.2, "Aditya"};
   printf("\ncgpa = %f\n", s1.cgpa);

   struct student *ptr = &s1;
   printf("name= %s\n", (*ptr).name);

   printf("roll no= %d\n", ptr->roll);

   //    printf("roll no. = %d\n", s1.roll);
   //    printf("cgpa = %f\n\n", s1.cgpa);

   return 0;
}