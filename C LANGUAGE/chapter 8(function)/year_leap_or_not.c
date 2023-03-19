#include <stdio.h>

void year(int year);

int main()
{

    int yr;
    printf("Enter the year: ");
    scanf("%d", &yr);

    year(yr);

    return 0;
}

void year(int yr)
{
    if (yr % 100 == 0)
    {
        if (yr % 400 == 0)
        {
            printf("leap year");
        }
        else
        {
            printf("not  leap year");
        }
    }
    else
    {
        if (yr % 4 == 0)
        {
            printf("a leap year");
        }
        else
        {
            printf("not a leap year");
        }
    }
}
