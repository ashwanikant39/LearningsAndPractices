#include <stdio.h>
int main()
{
    int mainNum, D1, D2, D3, D4, D5, num, num1, num2, num3, num4;
    long int revnum;
    printf("enter any 5 digit number:");
    scanf("%d", &mainNum); // 12345 or 12321

    D1 = mainNum % 10;   // 5
    num1 = mainNum / 10; // 1234
    D2 = num1 % 10;      // 4
    num2 = num1 / 10;    // 123
    D3 = num2 % 10;      // 3
    num3 = num2 / 10;    // 12
    D4 = num3 % 10;      // 2
    num4 = num3 / 10;    // 1
    D5 = num4;           //

    revnum = D1 * 10000 + D2 * 1000 + D3 * 100 + D4 * 10 + D5;

    printf("%ld", revnum);

    if (mainNum == revnum)
    {
        printf("\nboth are equal");
    }
    else
    {
        printf("\nboth are not equal");
    }

    return 0;
}