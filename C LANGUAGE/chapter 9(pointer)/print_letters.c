#include <stdio.h>

void max(int *, int *);
int main()
{
    int a, b;
    printf("Enter the a, b: ");
    scanf("%d %d", &a, &b);

    max(&a, &b);

    return 0;
}
void max(int *a, int *b)
{
    if (*a > *b)
        printf("%d is max", *a);
    else
        printf("%d is max", *b);
}