#include <stdio.h>
int main()
{
   int num, prime = 1;
   printf("enter the number for cheaking prime or not:: ");
   scanf("%d", &num);

   for (int i = 2; i < num; i++)
   {
      if (num % i == 0)
      {
         prime = 0;
      }
   }

   if (prime)
      printf("prime number");
   else
      printf("not prime number");

   return 0;
}