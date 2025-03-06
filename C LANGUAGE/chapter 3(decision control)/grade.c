// C Program to Find Grade of a Student Using If else Ladder
#include <stdio.h>

int main()
{
    int subject_1, subject_2, subject_3, subject_4, subject_5;

    printf("Enter the marks of five subjects::\n");
    scanf("%d%d%d%d%d", &subject_1, &subject_2, &subject_3, &subject_4, &subject_5);

    int total = subject_1 + subject_2 + subject_3 + subject_4 + subject_5;

    if (total >= 90)
    {
        printf("grade is A\n");
        if (total % 2 == 0)
        {
            printf("this is even number also\n");
        }
        else
        {
            printf("this is odd number also\n");
        }
    }
    else if (total >= 80 && total < 90)
    {
        printf("grade is B");
    }
    else if (total >= 70 && total < 80)
    {
        printf("grade is C");
    }
    else if (total >= 60 && total < 70)
    {
        printf("grade is D");
    }
    else
    {
        printf("grade is E\n ");
        printf("he is fail also\n");
        if (total % 2 == 0)
        {
            printf("failure number is even");
        }
        else
        {
            printf("failure nember is odd");
        }
    }

    return 0;
}