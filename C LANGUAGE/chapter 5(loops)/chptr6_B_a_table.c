#include <stdio.h>
int main()
{

  int num, i;
  printf("\n\nenter number for table: ");
  scanf("%d", &num);

  printf("\n         (table of %d)   \n\n", num);

  for (i = 1; i <= 10; i++)
    printf("%d * %d= %d\n", num, i, num * i);

  return 0;
}