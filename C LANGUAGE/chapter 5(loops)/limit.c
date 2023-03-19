#include <stdio.h>
int main()
{
    int limit, num;
    printf("enter the limit: ");
    scanf("%d", &limit);

    while (limit)
    {
        scanf("%d", &num);

        if (num == 5)
        {
            break;
        }
        limit--;
    }
    printf("you entered digit 5");

    return 0;
}