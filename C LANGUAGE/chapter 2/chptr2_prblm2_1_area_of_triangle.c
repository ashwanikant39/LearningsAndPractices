#include <stdio.h>
#include <math.h> /*for sqrt() */

int main()
{

    float a, b, c, sp, area;
    printf("enter the sides:");
    scanf("%f %f %f", &a, &b, &c);

    sp = (a + b + c) / 2;
    area = sqrt(sp * (sp - a) * (sp - b) * (sp - c));
    printf("area of tringle= %f\n", area);

    return 0;
}
