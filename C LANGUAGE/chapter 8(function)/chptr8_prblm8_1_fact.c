#include <stdio.h>

int factorial(int);
int main()
{

  int num;
  int fact;
  printf("Enter the mumber: ");
  scanf("%d", &num);

  fact = factorial(num);
  printf("factorial is %d", fact);
  return 0;
}

int factorial(int num)
{
  int fact = 1;
  for (int i = 1; i <= num; i++)

    fact = fact * i;
  return fact;
}
