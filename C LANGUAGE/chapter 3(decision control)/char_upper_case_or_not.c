

#include <stdio.h>
int main()
{
    char ch;
    printf("enter tha character=");
    scanf("%c", &ch);

    if ('A' <= ch && 'Z' >= ch)
    {
        printf("it is upper case character");
    }
    else if ('a' <= ch && 'z' >= ch)
    {
        printf("it is lower case character");
    }

    else
    {
        printf("not a english letter");
    }
    return 0;
}