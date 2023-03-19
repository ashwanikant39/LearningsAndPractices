#include <stdio.h>
struct address
{
    int houseno;
    int blockno;
    char city[100];
    char state[100];
};

int main()
{
    struct address add[5];
    for (int i = 0; i < 5; i++)
    {
        printf("\nEnter nouse No, block No,  City name, state for %dth person: \n", i + 1);
        scanf("%d %d %s %s", &add[i].houseno, &add[i].blockno, add[i].city, add[i].state);
    }
    printf("\n\nyou entered this... \n\n");
    for (int i = 0; i < 5; i++)
    {
        printf("address of %dth person = %d %d %s %s\n", i + 1, add[i].houseno, add[i].blockno, add[i].city, add[i].state);
    }
    return 0;
}