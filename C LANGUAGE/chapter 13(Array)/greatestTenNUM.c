#include <stdio.h>
int main()
{
    int a[10] = {1, 2, 3, 4, 10, 5, 6, 7, 8, 9};
    int i = 0;
    int greatest;
    // printf("Enter ten values:");
    // // Store 10 numbers in an array
    // for (i = 0; i < 10; i++)
    // {
    //     scanf("%d", &a[i]);
    // }
    // Assume that a[0] is greatest
    // greatest = a[0];
    // for (i = 0; i < 10; i++)
    // {
    //     if (a[i] > greatest)
    //     {
    //         greatest = a[i];
    //     }
    // }
    // printf("Greatest of ten numbers is %d", greatest);
    greatest = a[0];
    while (i <= 10)
    {
        if (a[i] > greatest)
        {
            greatest = a[i];
        }
        i++;
    }
    printf("great= %d", greatest);
    return 0;
}