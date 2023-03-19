#include <stdio.h>
void _name(char arr[]);
int main()
{
    // char firstname[]= {'A','d','i','t','y','a','\0'};
    // char lastname[]= {'P','a','n','d','e','y','\0'};
    char firstname[] = "Aditya";
    char lastname[] = "Pandey";

    _name(firstname);
    _name(lastname);
    return 0;
}
void _name(char arr[])
{
    for (int i = 0; arr[i] != '\0'; i++)
    {
        printf("%c", arr[i]);
    }
    printf("\t");
}