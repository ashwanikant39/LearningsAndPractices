#include <stdio.h>

// rewrite code useing coditional opterator
int main()
{
    int sal;
    printf("enter tha salary:");
    scanf("%d", &sal);

    ((sal >= 25000 && sal <= 40000) ? ((sal % 2 == 0) ? printf("manager'salary is even") : printf("manager's salary is odd")) : ((sal >= 15000 && sal < 25000) ? printf("accountant") : printf("clerk")));

    return 0;
}