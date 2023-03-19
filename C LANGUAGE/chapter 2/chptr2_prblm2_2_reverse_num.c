#include <stdio.h>
int main()
{
   int num, D5, D4_num, D4, D3_num, D3, D2_num, D2, D1;
   long int revnum;                    // for long digit
   printf("enter the five number:\n"); // like 12345
   scanf("%d", &num);

   // num formate= D1*10000+D2*1000+D3*100+D4*10+D5

   D5 = num % 10;
   D4_num = num / 10;
   D4 = D4_num % 10;
   D3_num = D4_num / 10;
   D3 = D3_num % 10;
   D2_num = D3_num / 10;
   D2 = D2_num % 10;
   D1 = D2_num / 10;

   // reverse num formate= D5*10000+D4*1000+D3*100+D2*10+D1
   revnum = D5 * 10000 + D4 * 1000 + D3 * 100 + D2 * 10 + D1;
   printf("the reversed number is= %ld\n", revnum);

   return 0;
}