#include <stdio.h>
#include <string.h>
void slice(char sent[], int n, int m);
int main()
{
    char sent[100] = "adityapandey";
    // printf("Enter the sentence: ");
    // fgets(sent, 100, stdin);
    slice(sent, 3, 6);

    return 0;
}
void slice(char sent[], int n, int m)
{
    char aftcut[100];
    int j = 0;

    for (int i = n; i <= m; i++, j++)
    {
        aftcut[j] = sent[i];
    }
    aftcut[j] = '\0';
    puts(aftcut);
}
