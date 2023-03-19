#include <stdio.h>
int main()
{
    int count = 0;
    int num[] = {3, 4, -5, -6, -2};
    for (int i = 0; i < 5; i++)
    {
        if (num[i] > 0)
        {
            count++;
        }
    }

    printf("%d positive", count);

    return 0;
}