#include <stdio.h>

int main()
{
    int num, i = 1, rem, sum;

    while (i <= 500)
    {
        num = i;
        sum = 0;

        while (num)
        {
            rem = num % 10;
            sum = sum + (rem * rem * rem);
            num = num / 10;
        }

        if (i == sum)
        {
            printf("%d is a Armstrong number\n", i);
        }

        i++;
    }

    return 0;
}
