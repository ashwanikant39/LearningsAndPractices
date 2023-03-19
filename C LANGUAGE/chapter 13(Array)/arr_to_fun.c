#include <stdio.h>
void array(int ptr[], int n);

int main()
{
    int arr[] = {3, 5, 56, 65, 65, 54};
    array(&arr[0], 6);

    return 0;
}
void array(int ptr[], int n)
{
    for (int i = 0; i < n; i++)
    {
        printf("the value of element %dth is %d\n", i, ptr[i]);
    }
}