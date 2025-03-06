
#include <stdio.h>

int main()
{
  int a;
  printf("enter tha num: ");
  scanf("%d", &a);

  if (a % 2 == 0)
  {
    printf("this is even number\n");
    printf("this can divide b2 2\n");
  }

  else
  {
    printf("this is odd number\n");
    printf("this  can't divided by 2\n");
  }
  return 0;
}
