#include <stdio.h>
int main()
{
    char firstname[50];
    printf("Enter youe first name: ");
    scanf("%s", firstname);

    printf("your name is '%s'", firstname);

    return 0;
}