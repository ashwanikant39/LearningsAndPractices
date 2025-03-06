#include <stdio.h>
int main()
{
    float s1, s2, s3;
    printf("enter three sides s1, s2, s3: ");
    scanf("%f %f %f", &s1, &s2, &s3);

    if (s1 == s2 && s2 == s3 && s3 == s1)
        printf("equailateral");

    else if ((s1 == s2) || (s2 == s3) || (s3 == s1))
        printf("isosceles triangle");

    else if (s2 < s1 && s1 > s3)
    {
        if ((s1 * s1) == (s2 * s2) + (s3 * s3))
            printf("right angle");
    }
    else if (s1 < s2 && s2 > s3)
    {
        if ((s2 * s2) == (s1 * s1) + (s3 * s3))
            printf("right angle");
    }
    else if (s1 < s3 && s3 > s2)
        if ((s3 * s3) == (s1 * s1) + (s2 * s2))
            printf(" right angle");
        else
            printf("scalene");

    return 0;
}