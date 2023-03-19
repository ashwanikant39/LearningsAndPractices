#include <stdio.h>
int main()
{
    char s[] = "get organized! learn C!!";
    printf("\n%s\n", &s[2]);
    printf("%s\n", s);
    printf("%s\n", &s);
    printf("%c\n", &s[2]);

    return 0;
}