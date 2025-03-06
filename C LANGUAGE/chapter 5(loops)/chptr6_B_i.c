#include<stdio.h>
#include<conio.h>
int main()
{
    int i, j, k, count=1;

    //for loop for all the rows=4

    for(i=1;i<=4;i++)
    {
        //add left space for pattern
        for(j=1;j<=4-i;j++)
        {
            printf("*");
        }

        //add element after space
        for(k=1;k<=i;k++)
        {
            printf(" %d",count);
            count++;
        }

    printf("\n");

    }
}