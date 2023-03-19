#include <stdio.h>

float fahrenheight(float c);

int main()
{
    float c;
    printf("enter the value in c: ");
    scanf("%f", &c);

    float far = fahrenheight(c);
    printf("far= %f", far);
    return 0;
}

float fahrenheight(float c)
{
    float far = c * (9.0 / 5.0) + 32;
    return far;
}