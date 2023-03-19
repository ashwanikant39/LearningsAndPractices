#include <stdio.h>
int countlength(char arr[]);
int main()
{
    char name[100];
    fgets(name, 100, stdin);
    countlength(name);
    int x = countlength(name);
    printf("lenght is %d", x);
    return 0;
}
int countlength(char arr[])
{
    int count = 0;
    for (int i = 0; arr[i] != '\0'; i++)
    {
        // if(arr[i]=='I') //FOR COUNT NUMBER
        count++;
    }
    return count - 1; // FOR COUNT LENGHT
}