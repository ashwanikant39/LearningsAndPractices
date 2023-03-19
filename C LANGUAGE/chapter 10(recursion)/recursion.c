#include <stdio.h>
int sum(int x);

int main()
{

    printf("sum is %d", sum(3));

    return 0;
}
int sum(int x)
{
    if (x == 1)
    {
        return 1;
    }
    int sumNm1 = sum(x - 1);
    int sum = x + sumNm1;
    return sum;
}