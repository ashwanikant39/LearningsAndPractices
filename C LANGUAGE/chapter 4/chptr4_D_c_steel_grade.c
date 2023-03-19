#include <stdio.h>
int main()
{
    int hrd, tnsl;
    float car;
    printf(" enter the  HARDNESS, CARBON, TENSILE: ");
    scanf("%d %f %d", &hrd, &car, &tnsl);

    if (hrd > 50 && car < 0.7 && tnsl > 5600)
        printf("10");

    else if (hrd > 50 && car < 0.7)
        printf("9");

    else if (car < 0.7 && tnsl > 5600)
        printf("8");

    else if (hrd > 50 && tnsl > 5600)
        printf("7");

    else if (((hrd > 50) && !(car < 0.7) && !(tnsl > 5600)) || (!(hrd > 50) && (car < 0.7) && !(tnsl > 5600)) || (!(hrd > 50) && !(car < 0.7) && (tnsl > 5600)))
        printf("6");

    else
        printf("5");

    return 0;
}
