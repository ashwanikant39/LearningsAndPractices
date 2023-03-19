#include <stdio.h>
void modify(int arr[], int);

int main()
{
  printf("\n\n\t\t(original value)\n\n");
  int arr[] = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
  for (int i = 0; i < 10; i++)
  {
    printf("\t %dth element is %d\n", i + 1, arr[i]);
  }
  printf("\n\t\t(new value)\n\n");
  modify(&arr[0], 10);
  return 0;
}
void modify(int arr[], int n)
{
  int i;
  for (i = 0; i < n; i++)
  {
    printf("\t%dth element is %d\n", i + 1, arr[i]* 3);
    // ptr++;
  }
}
