#include <stdio.h>
void fun(int *, int *);
int main()
{
  int i = 5, j = 2;

  printf("%d %d\n", i, j);

  fun(&i, &j);
  printf("%d %d\n", i, j);

  return 0;
}
void fun(int *i, int *j)
{
  *i = (*i) * (*i);
  *j = (*j) * (*j);
}