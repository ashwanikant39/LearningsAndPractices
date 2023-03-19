#include <stdio.h>
int main()
{
    int a, b, t;
    printf("enter A and B:");
    scanf("%d %d", &a, &b);

    t = a;
    a = b;
    b = t;

    printf("after enterchange\n A= %d\n b= %d", a, b);
}