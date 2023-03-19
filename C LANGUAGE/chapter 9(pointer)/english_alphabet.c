#include <stdio.h>

void lettrs(char);
int main()
{
    char ch;
    lettrs(ch);

    return 0;
}
void lettrs(char ch)
{
    char i;
    for (char i = 'A'; i <= 'Z'; i++)
    {
        if (i == 'B')
        {
            continue;
        }
        printf("%c\n", i);
    }
}