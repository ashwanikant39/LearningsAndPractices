// interchange odd position
#include <stdio.h>
int main()
{
    int num[] = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
    int i, t;
    for (i = 0; i < 10; i = i + 2)
    {
        t = num[i];
        num[i] = num[i + 1];
        num[i + 1] = t;
    }

    for (i = 0; i <= 9; i++)
        printf("%d\t", num[i]);

    return 0;
}