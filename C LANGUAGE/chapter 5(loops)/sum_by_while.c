#include <stdio.h>
int main()
{
    int i, sum, num;
    printf("enter the num: ");
    scanf("%d", &num);

    sum = 0;
    i = 1;
    while (i <= num)
    {
        sum = sum + i;
        i++;
    }
    printf("%d", sum);

    return 0;
}