#include <stdio.h>

int swap(int *, int *);

int main()
{
    int a = 10, b = 15;
    printf("a= %d, b= %d\n", a, b);
    swap(&a, &b);

    printf("a= %d, b= %d", a, b);

    return 0;
}
int swap(int *x, int *y)
{
    int t;
    t = *x;
    *x = *y;
    *y = t;
}
