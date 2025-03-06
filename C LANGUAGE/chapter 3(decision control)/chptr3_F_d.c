#include <stdio.h>
#include <math.h> //for for abs(), is a function in C
int main()
{
    int num, absolute_num;
    printf("enter the num:");
    scanf("%d", &num);

    absolute_num = abs(num);

    printf("absolute number of %d is %d", num, absolute_num);

    return 0;
}