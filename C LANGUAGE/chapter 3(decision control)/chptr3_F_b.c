#include <stdio.h>
int main()
{
    int R_age, S_age, A_age;
    printf("epnter the age of RAM:");
    scanf("%d", &R_age);
    printf("epnter the age of SHYAM:");
    scanf("%d", &S_age);
    printf("epnter the age of AJAY:");
    scanf("%d", &A_age);

    if (S_age > R_age && R_age < A_age)
    {
        printf("ram is youngest");
    }
    else if (R_age > S_age && S_age < A_age)
    {
        printf("shyam is youngest");
    }
    else if (R_age > A_age && A_age < S_age)
    {
        printf("ajay is youngest");
    }
    else if (R_age == S_age && S_age == A_age && A_age == R_age)
    {
        printf("all three are same age");
    }

    return 0;
}