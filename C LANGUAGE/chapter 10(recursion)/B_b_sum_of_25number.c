// sum of first 25 number

#include <stdio.h>
int sum25(int);

int main()
{

    int x = sum25(20);
    printf("sum is %d", x);
    return 0;
}
int sum25(int n)
{
    if (n == 0)
    {
        return 0;
    }
    return (n + sum25(n - 1));
}