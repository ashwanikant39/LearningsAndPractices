#include <stdio.h>
int main()
{
  printf("\n\n\n\n\n\n        (all combination of 1,2 or 3)     \n\n");

  int i, j, k;

  for (int i = 1; i <= 3; i++)
  {

    for (j = 1; j <= 3; j++)
    {

      for (k = 1; k <= 3; k++)

        printf("%d %d %d\n", i, j, k);
    }
  }

  printf("\n   (Thank you)      \n");

  return 0;
}