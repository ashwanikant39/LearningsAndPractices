#include <stdio.h>
int main()
{
    int y;
    printf("enter the year:");
    scanf("%d", &y);

    (y % 100 == 0) ? ((y % 400 == 0) ? printf("it is a leap year\n") : printf("it is not a leap year\n")) : ((y % 4 == 0) ? printf("it is a leap year\n") : printf("it is not a leap year\n"));

    return 0;
}