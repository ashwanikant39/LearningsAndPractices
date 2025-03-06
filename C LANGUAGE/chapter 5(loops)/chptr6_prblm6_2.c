#include <stdio.h>
int main()
{

    float sum = 0.0, fact;

    for (int i = 1; i <= 7; i++)
    {
        fact = 1.0;
        for (int j = 1; j <= i; j++)
            fact = fact * j;

        sum = sum + i / fact;
    }
    printf("final answer is %f", sum);

    return 0;
}