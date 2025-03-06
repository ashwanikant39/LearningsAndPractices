#include <stdio.h>
int main()
{
    int marks;
    printf("enter tha marks=");
    scanf("%d", &marks);

    if (marks < 30)
    {
        printf("grade is C");
    }
    else if (30 <= marks && marks < 70)
    {
        printf("grade is B");
    }
    else if (70 <= marks && marks < 90)
    {
        printf("grade is A");
    }
    else if (90 <= marks && marks <= 100)
    {
        printf("grade is A++");
    }
    else
    {
        printf("wrong marks");
    }
    return 0;
}