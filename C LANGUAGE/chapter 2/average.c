#include<stdio.h>
int main ()
{
    int a, b, c, d;
    float avg;
    printf("enter the value of a, b, c, d:");
    scanf("%d %d %d %d", &a, &b, &c, &d);
    
    avg= (a+b+c+d)/4.0;
    printf("avrage of 4 digit= %f\n", avg);

return 0; 
}
