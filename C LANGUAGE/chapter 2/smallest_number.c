#include <stdio.h>
int main()
{
    int a, b;
    printf("enter a:");
    scanf("%d", &a);

    printf("enter b:");
    scanf("%d", &b);

    if (a > b)
    {
        printf("B is smallest number");
    }
    else
    {
        printf("A is smallest number");
    }

    return 0;
}