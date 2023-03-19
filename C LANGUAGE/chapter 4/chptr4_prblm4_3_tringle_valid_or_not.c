#include <stdio.h>
int main()
{
    float s1, s2, s3;
    printf("enter three sides s1, s2, s3: ");
    scanf("%f %f %f", &s1, &s2, &s3);

    if (s2 < s1 && s1 > s3)
    {
        if (s1 < (s2 + s3))
        {
            printf("valid");
        }
        else
        {
            printf("invalid");
        }
    }
    else if (s1 < s2 && s2 > s3)
    {
        if (s2 < (s1 + s3))
        {
            printf("valid");
        }
        else
        {
            printf("invalid");
        }
    }
    else
    {
        if (s3 < (s1 + s2))
        {
            printf("valid");
        }
        else
        {
            printf("invalid");
        }
    }

    return 0;
}