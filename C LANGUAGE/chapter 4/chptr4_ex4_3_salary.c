#include <stdio.h>
int main()
{
    char sex, qual;
    int yos;
    printf("enter the SEX(M,F), YEAR OF SERVICE, QUALIFICATIONS(P,G): ");
    scanf("%c %d %c", &sex, &yos, &qual);

    if (sex == 'M')
    {
        if (yos >= 10 && qual == 'P')
        {
            printf("salary = 11000");
        }
        else if (yos >= 10 && qual == 'G')
        {
            printf("salary= 10000");
        }
        else if (yos < 10 && qual == 'P')
        {
            printf("salary= 10000");
        }
        else
        {
            printf("salary= 7000");
        }
    }
    else if (sex == 'F')
    {
        if (yos >= 10 && qual == 'P')
        {
            printf("salary = 12000");
        }
        else if (yos >= 10 && qual == 'G')
        {
            printf("salary= 9000");
        }
        else if (yos < 10 && qual == 'P')
        {
            printf("salary= 10000");
        }
        else
        {
            printf("salary= 6000");
        }
    }
    else
    {
        printf(" you entered somthing wrong");
    }

    return 0;
}