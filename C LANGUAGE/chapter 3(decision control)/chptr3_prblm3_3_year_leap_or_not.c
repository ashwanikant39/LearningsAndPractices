#include <stdio.h>
int main()
{
    int y;
    printf("enter the year:");
    scanf("%d", &y);

    if (y % 100 == 0)
    {
        if (y % 400 == 0)
        {
            printf("it is a leap year\n");
        }
        else
        {
            printf("it is not a leap year\n");
        }
    }
    else
    {
        if (y % 4 == 0)
        {
            printf("it is a leap year\n");
        }
        else
        {
            printf("it is not a leap year\n");
        }
    }

    return 0;
}