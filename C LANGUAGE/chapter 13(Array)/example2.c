#include <stdio.h>
int main()
{
    int num[] = {10, 20, 30, 45, 67, 56};
    int i, *ptr;
    ptr = &num[0];
    for (i = 0; i <= 5; i++)
    {
        printf("addresss= %u\t element= %d", ptr, *ptr);
        printf("\n");
        ptr++;
    }
    printf("\n");

    for (i = 0; i <= 5; i++)
    {
        printf("addresss= %u\t element= %d", ptr, num[i]);
         ptr++;
        printf("\n");
    }
    return 0;
}
