#include <stdio.h>
int main()
{
    int marks;
    printf("enter tha marks");
    scanf("%d", &marks);

    if (marks >= 30 && marks <= 100)
    {
        printf("passed");
    }
    else if (marks >= 0 && marks < 30)
    {
        printf("failed");
    }
    else
    {
        printf("marks is not allowed");
    }

    return 0;
}