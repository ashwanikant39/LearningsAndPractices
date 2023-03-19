#include <stdio.h>
int main()
{
  int count = 0, n;
  int arr[] = {7, 3, 4, 5, 9, 9, 7, 5};

  printf("Enter the num: ");
  scanf("%d", &n);

  for (int i = 0; i <= 7; i++)
  {
    if (arr[i] == n)
      count++;
  }
  printf("total  num(%d) found= %d",n,  count);
  return 0;
}
