#include <stdio.h>
int main()
{
    int n;
    printf("enter the num: ");
    scanf("%d", &n);

    for (int i = 1; i <= 10; i++)
    {

        printf("%d * %d = %d\n", n, i, n * i);
    }

    //  for(int i=n; i>=1; i--){
    //      printf("%d\n", i);
    //  }

    return 0;
}