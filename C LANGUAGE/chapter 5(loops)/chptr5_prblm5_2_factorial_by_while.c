#include <stdio.h>
int main()
{
    int n;
    printf("enter number for factoil: ");
    scanf("%d", &n);

    int fact = 1;
    int i = 1;
    while (i <= n)
    {

        fact = fact * i;
        i++;
    }

    printf("factorial of %d = %d", n, fact);

    return 0;
}