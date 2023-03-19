#include <stdio.h>
void ans(int *, float *);

int main()
{

    int sum;
    float avg;

    ans(&sum, &avg);
    printf("the sum is= %d\nthe avg is= %f\n", sum, avg);

    return 0;
}
void ans(int *sum, float *avg)
{
    int n1, n2, n3, n4, n5;
    printf("enter the five number: ");
    scanf("%d %d %d %d %d", &n1, &n2, &n3, &n4, &n5);

    *sum = n1 + n2 + n3 + n4 + n5;
    *avg = *sum / 5.0;
}