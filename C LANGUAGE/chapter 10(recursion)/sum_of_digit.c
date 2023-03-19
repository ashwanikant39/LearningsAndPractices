#include <stdio.h>
int rec_func(int num);

void main()
{
    int num, rec, non_rec;
    printf("Enter an integer: ");
    scanf("%d", &num);

    rec = rec_func(num);

    printf("\n Calculate sum using recursion: %d", rec);
}

int rec_func(int num)
{
    if (num == 0)
    {
        return 0;
    }

    return (num % 10 + rec_func(num / 10));
}
