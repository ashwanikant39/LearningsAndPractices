#include <stdio.h>
int main()
{
    int num, D1, D2, D3, aft_D1, aft_D2;
    printf("enter the num=");
    scanf("%d", &num);
    D1 = num % 10;
    aft_D1 = num / 10;
    D2 = aft_D1 % 10;
    aft_D2 = aft_D1 / 10;
    D3 = aft_D2 % 10;

    if (num == ((D1 * D1 * D1) + (D2 * D2 * D2) + (D3 * D3 * D3)))
    {
        printf("num is armstrong");
    }
    else
    {
        printf("it is not armstrong");
    }

    return 0;
}