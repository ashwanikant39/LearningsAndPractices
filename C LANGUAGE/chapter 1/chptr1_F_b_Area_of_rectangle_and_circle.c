#include <stdio.h>
int main()
{
    float l, b, r, aor, por, aoc, coc;
    printf("enter the lenght:");
    scanf("%f", &l);

    printf("enter the breadth:");
    scanf("%f", &b);

    printf("enter the radius:");
    scanf("%f", &r);

    /* formula*/
    aor = l * b;
    printf("area of rectangle= %f\n", aor);

    por = 2 * (l + b);
    printf("perimeter of rectangle= %f\n", por);

    aoc = 3.14 * r * r;
    printf("area pf circle= %f\n", aoc);

    coc = 2 * 3.14 * r;
    printf("circumference of circle= %f\n", coc);

    return 0;
}
