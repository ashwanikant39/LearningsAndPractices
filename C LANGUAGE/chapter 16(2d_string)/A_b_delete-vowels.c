#include <stdio.h>
void dltvwl(char sen[]);
int main()
{
    char sen[80];
    printf("\n\nEnter the sentence: ");
    //   scanf("%c", &sen);
    fgets(sen, 80, stdin);

    dltvwl(sen);
    return 0;
}
void dltvwl(char sen[])
{
    int i;
    for (int i = 0; sen[i] != '\0'; i++)
    {
        if (sen[i] == 'a' || sen[i] == 'e' || sen[i] == 'i' || sen[i] == 'o' || sen[i] == 'u')
        {
            continue;
        }
        else
        {
            printf("%c", sen[i]);
        }
    }
}
