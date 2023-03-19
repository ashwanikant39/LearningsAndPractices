#include <stdio.h>
int main()
{
   int num[5];
   int n, i, count_positive = 0, count_negetive = 0, count_even = 0, odd=0;
   printf("enter 5 num: ");
   for (int i = 0; i < 5; i++)
   {
      scanf("%d", &num[i]);
   }
   for (int i = 0; i < 5; i++)
   {
      if (num[i] > 0)
         count_positive++;
      if (num[i] < 0)
         count_negetive++;
      if (num[i] % 2 == 0)
         count_even++;
      if (num[i] % 2 != 0)
         odd++;
   }
   printf("positive=%d\n negative= %d\n even=%d\n odd=%d", count_positive, count_negetive, count_even, odd);
   return 0;
}