#include <stdio.h>
struct costumer_data
{
    int acc_num;
    char name[50];
    int balance;
} noc[200] = {01, "aditya", 2000,
              02, "Akash", 1000,
              03, "Ashu", 400,
              04, "ashwani", 5000,
              05, "ankush", 500};

void under1000()
{
    for (int i = 0; i <= 200; i++)
    {
        if (noc[i].balance < 1000 && noc[i].balance > 0)
        {
            printf("account no= %d\n", noc[i].acc_num);
            printf("name= %s\n", noc[i].name);
        }
    }
}
int main()
{
    // int amount;
    // printf("Enter the amount: ");
    // scanf("%d", &amount);
    under1000();

    return 0;
}