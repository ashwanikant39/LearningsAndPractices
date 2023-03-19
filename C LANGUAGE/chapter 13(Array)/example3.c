#include <stdio.h>
void display1(int *, int);
void display2(int[], int);
int main()
{
    int i;
    int num[] = {55, 65, 75, 67, 45, 0};
    display1(&num[0], 6);
    display2(&num[0], 6);
    return 0;
}
void display1(int *ptr, int n)
{
    int i;
    for (i = 0; i < n; i++)
    {
        printf("element=%d\t", *ptr);
        ptr++;
    }
    printf("\n");
}
void display2(int ptr[], int n)
{
    int i;
    for (i = 0; i <n ; i++)

        printf("element=%d\t", ptr[i]);
}