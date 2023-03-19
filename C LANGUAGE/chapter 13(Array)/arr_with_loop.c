#include <stdio.h>
int main()
{
  int marks[6];

  for (int i = 0; i < 6; i++)
  {
    printf("Enter the marks of %dth student: ", i + 1);
    scanf("%d", &marks[i]);
  }
  for (int i = 0; i < 6; i++)
  {
    printf("the value of marks of %dth student is %d\n", i + 1, marks[i]);
  }

  return 0;
}