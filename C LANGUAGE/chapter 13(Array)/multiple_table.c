#include <stdio.h>
int printtable(int arr[][10], int, int);
int main()
{
    int arr[2][10];
    printf("\n");
    printtable(arr, 0, 2);
    printf("\n");
    printtable(arr, 1, 7);
    printf("\n\n");
    return 0;
}
int printtable(int arr[][10], int row, int num)
{
    int table, i;
    for (int i = 0; i < 10; i++)
    {
        arr[row][10] = num * (i + 1);
        printf("%d\t", arr[row][10]);
    }
}
