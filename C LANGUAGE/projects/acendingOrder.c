#include <stdio.h>
void main()
{

    int i, a, n, number[30] = {10, 5, 9, 2, 1, 8, 125, 515, 122};
    // printf("Enter the value of N \n");
    // scanf("%d", &n);

    // printf("Enter the numbers \n");
    // for (i = 0; i < n; ++i)
    //     scanf("%d", &number[i]);
    for (i = 0; i <= 8; i++)
        printf("%d ", number[i]);
        
        printf("\n");
    for (int i = 0; i <= 8; i++)
    {

        for (int j = i + 1; j <= 8; j++)
        {

            if (number[i] > number[j])
            {

                a = number[i];
                number[i] = number[j];
                number[j] = a;
            }
        }
    }

    printf("The numbers arranged in ascending order are given below \n");
    for (i = 0; i <= 8; i++)
        printf("%d ", number[i]);
}
