#include <stdio.h>

int shift(int *, int *, int *);

int main()
{
    int x = 5, y = 8, z = 10;
    shift(&x, &y, &z);

    // shift(&x, &y, &z);
    printf("z= %d, x= %d y= %d\n", z, x, y);

    return 0;
}
int shift(int *x, int *y, int *z)
{
    int t;
    t = *z;
    *z = *y;
    *y = *x;
    *x = t;
}