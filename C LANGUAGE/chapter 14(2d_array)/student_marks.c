#include <stdio.h>
int main()
{
    int stud[4][5];
    int i;
    for (i = 0; i <= 3; i++)
    {
        printf("Enter the roll num and marks: ");
        scanf("%d%d", &stud[i][0], &stud[i][1]);
    }
    for (i = 0; i <= 3; i++)
    {
        printf("\n%d\t= %d\n", stud[i][0], stud[i][1]);
    }
    return 0;
}