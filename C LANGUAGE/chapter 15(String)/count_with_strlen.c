#include <stdio.h>
#include <string.h>
int main()
{
    char name[100] = "aditya";
    int lenght;
    // printf("Enter the name or sentence: ");
    // fgets(name,100,stdin);
    lenght = strlen(name);
    printf("%d\n", lenght);
    printf("%d\n", strlen(name));

    return 0;
}