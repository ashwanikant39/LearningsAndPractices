#include <stdio.h>
#define ISUPPER(x) (x >= 'A' && x <= 'Z' ? 1 : 0)
#define ISLOWER(x) (x >= 'a' && x <= 'z' ? 1 : 0)
#define ALPHA(x) (ISUPPER(x) || (ISLOWER(x)))
#define BIG(x, y) (x > y ? x : y)
int main()
{

       char ch;
       int a, b, d;
       printf("Enter the character/alphabet: ");
       scanf("%c", &ch);

       if (ISUPPER(ch) == 1)
              printf("upper case\n");

       if (ISLOWER(ch) == 1)
              printf("lower case\n");

       if (ALPHA(ch) == 0)
              printf("alpabet\n");

       printf("Enter two number: ");
       scanf("%d %d", &a, &b);

       d = BIG(a, b);
       printf("bigger num is= %d\n", d);
       return 0;
}