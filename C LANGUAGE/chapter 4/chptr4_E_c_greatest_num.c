#include <stdio.h>
int main()
{
    int n1, n2, n3;
    printf("enter three number: ");
    scanf("%d %d %d", &n1, &n2, &n3);

    (n2 < n1 && n1 > n3) ? printf(" greatest num= %d", n1) : (n1 < n2 && n2 > n3) ? printf("greatest num= %d", n2)
                                                                                  : printf(" greatest num= %d", n3);

    return 0;
}