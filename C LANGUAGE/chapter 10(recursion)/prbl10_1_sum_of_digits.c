// sum of digit of 5 digit num

#include <stdio.h>
int sum(int);
int main()
{
   int n;
   printf("Enter the 5 digit num: ");
   scanf("%d", &n);

   int x = sum(n);
   printf("sum of 5 digit is= %d", x);

   return 0;
}
int sum(int num)
{
   int rem;
   if (num == 0)
   {
      return 0;
   }
   rem = num % 10;
   int digit = sum(num / 10);
   int s = rem + digit;
   return s;
}