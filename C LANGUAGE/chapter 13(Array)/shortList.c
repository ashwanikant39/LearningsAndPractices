#include <stdio.h>
int main()
{
    int t;
    int arr[] = {100, 200, 30, 600, 5 ,1, 8000};

    int flag = 0;
    for (int i = 0; i < 7; i++)
    {
        for (int j = i + 1; j < 7; j++)
        {
            if (arr[i] < arr[j])
            {
                t = arr[i];
                arr[i] = arr[j];
                arr[j] = t;
            }
        }
            flag++;
    }
    for (int i = 0; i < 6; i++)
    {
        printf("%d\t ", arr[i]);
    }
    printf("\n%d rounds", flag);

    return 0;
}
