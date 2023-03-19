#include <stdio.h>
int main()
{
    float t;
    float arr[] = {1.1, .5, .3, 6.0, .005, 80};

    for (int i = 0; i < 6; i++)
    {
        for (int j = i + 1; j < 6; j++)
        {
            if (arr[i] < arr[j])
            {
                t = arr[i];
                arr[i] = arr[j];
                arr[j] = t;
            }
        }
    }
    for (int i = 0; i < 6; i++)
    {
        printf("%f\t ", arr[i]);
    }

    return 0;
}