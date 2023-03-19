#include<stdio.h>
int main()
{
    float km, m, cm, ft, inch;
    printf("enter the distance in km");
    scanf("%f", &km);
    
    m= km*1000;
    cm= m*100;
    inch= cm/2.54;
    ft= inch/12;
    printf("distance in KM= %f\n", km);
    printf("distance in M= %f\n", m);
    printf("distance in CM= %f\n", cm);
    printf("distance in inch= %f\n", inch);
    printf("distance in ft= %f\n", ft);
    
    return 0;
}

