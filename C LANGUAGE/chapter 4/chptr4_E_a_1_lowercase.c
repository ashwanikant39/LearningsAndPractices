#include <stdio.h>
int main()
{
    char ch;
    printf("enter the character: ");
    scanf("%c", &ch);

    ('a' <= ch && ch <= 'z') ? printf("lower case alphabet") : printf("not");

    return 0;
}