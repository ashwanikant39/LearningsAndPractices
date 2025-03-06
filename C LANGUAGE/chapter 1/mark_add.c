#include <stdio.h>
int main()
{
    float a, b, c, d, e;
    printf("enter the first subject mark:");
    scanf("%f", &a);

    printf("enter the second subject mark:");
    scanf("%f", &b);

    printf("enter the third subject mark:");
    scanf("%f", &c);

    printf("enter the fourth subject mark:");
    scanf("%f", &d);

    printf("enter the fifth subject mark:");
    scanf("%f", &e);

    float sum = a + b + c + d + e;
    printf("%f", sum);
    return 0;
}
