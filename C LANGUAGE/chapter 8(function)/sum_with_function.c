#include <stdio.h>
int sum(int, int);

int main()
{
    int a, b;
    printf("enter a, b: ");
    scanf("%d %d", &a, &b);

    int n = sum(a, b);
    printf(" sum= %d", n);
    return 0;
}
int sum(int a, int b)
{
    int x = a + b;
    return x;
}
