#include <stdio.h>
int main()
{
   int i = 3;
   switch (i)
   {
   case 0:
      printf("never\n");

   case 1 + 2:
      printf("always\n");
      break;

   case 4 / 2:
      printf("of course\n");
   }

   return 0;
}