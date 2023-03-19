#include <stdio.h>
int main()
{
    int a[5][5] = {
        222, 50, 100, 9, 4,
        13, 45, 21, 23, 12,
        25, 8, 5, 3, 2,
        10, 11, 24, 14, 16,
        15, 17, 89, 99, 213};
    int i, j, big;
    big = a[0][0];
    for (i = 0; i <= 4; i++)
    {
        for (j = 0; j <= 4; j++)
        {
            if (a[i][j] > big)
                big = a[i][j];
        }
    }
    printf("\nlargest= %d\n\n", big);
    return 0;
}