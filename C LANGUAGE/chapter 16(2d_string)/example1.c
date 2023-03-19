#include <stdio.h>
int main()
{
    char names[][20] = {
        "akashay", "pagar", "raman", "srinivas", "gopal", "rajesh"};

    printf("old: %s %s\n", &names[2][0], &names[3][0]);

    int i;
    char t;
    for (i = 0; i <= 19; i++)
    {
        t = names[2][i];
        names[2][i] = names[3][i];
        names[3][i] = t;
    }

    printf("new: %s %s\n", &names[2][0], &names[3][0]);

    return 0;
}