#include <stdio.h>
int main()
{
    char ch;
    printf("enter tha char: ");
    scanf("%c", &ch);

    if (ch >= '0' && ch <= '9')
    {
        printf("char is a digit");
    }
    else
    {
        printf("char is not a digit");
    }

    return 0;
}
