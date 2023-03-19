#include <stdio.h>
void wght(float, float *, float *, float *);

int main()
{
    float kg, gm, tn, pound;
    printf("Enter the waight in KG: ");
    scanf("%f", &kg);

    wght(kg, &gm, &tn, &pound);
    printf("%f kg\n%f gm\n%f ton\n%f pound\n", kg, gm, tn, pound);

    return 0;
}
void wght(float kg, float *gm, float *tn, float *pound)
{
    *gm = kg * 1000;
    *tn = kg / 1000;
    *pound = kg * 2.20462;
}