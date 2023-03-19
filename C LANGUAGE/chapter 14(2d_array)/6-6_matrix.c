#include <stdio.h>
int main()
{
    int mat1[6][6], mat2[6][6], mat3[6][6], i, j;
    printf("\nEnter the first matrix 6 *6: ");
    for (i = 0; i <= 5; i++)
    {
        for (j = 0; j <= 5; j++)
            scanf("%d", &mat1[i][j]);
    }
    printf("\nEnter the secon matrix 6 *6: ");
    for (i = 0; i <= 5; i++)
    {
        for (j = 0; j <= 5; j++)
            scanf("%d", &mat2[i][j]);
    }
    printf("\nmatrix entered by you: \nmatrix 1:\n");
    for (int i = 0; i <= 5; i++)
    {
        for (j = 0; j <= 5; j++)
            printf("%d\t", mat1[i][j]);
        printf("\n");
    }
    printf("\nmatrix 2:\n");
    for (int i = 0; i <= 5; i++)
    {
        for (j = 0; j <= 5; j++)
            printf("%d\t", mat2[i][j]);
        printf("\n");
    }
    // sum abovetwo matrix

    for (i = 0; i <= 5; i++)
    {
        for (j = 0; j < 5; j++)
            mat3[i][j] = mat1[i][j] + mat2[i][j];
    }
    printf("\nthe sum of two matrix is: \n");
    for (i = 0; i <= 5; i++)
    {
        for (j = 0; j <= 5; j++)
            printf("%d\t", mat3[i][j]);
        printf("\n");
    }

    return 0;
}