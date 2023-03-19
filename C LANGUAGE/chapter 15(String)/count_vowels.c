#include <stdio.h>
int countlength(char arr[]);
int main()
{
    char name[100];
    printf("Enter the sentence: ");
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
        if (arr[i] == 'a' || arr[i] == 'e' || arr[i] == 'i' || arr[i] == 'o' || arr[i] == 'u') // FOR COUNT NUMBER
            count++;
    }
    return count; // FOR COUNT LENGHT
}