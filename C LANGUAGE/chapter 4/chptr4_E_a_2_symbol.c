#include <stdio.h>
int main()
{
    char ch;
    printf("enter the character: ");
    scanf("%c", &ch);

    (('0' <= ch && ch <= '9') || ('a' <= ch && ch <= 'z') || ('A' <= ch && ch <= 'Z')) ? printf("not a special symbol") : printf("special symbol");

    return 0;
}