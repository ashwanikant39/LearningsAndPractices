#include<stdio.h>
int main()
{
    /*calculation of aggregate & percentage mark */
    
   int m1, m2, m3, m4, m5, aggr;
   float per;
   printf("enter marks in 5 subjects\n");
   scanf("%d %d %d %d %d", &m1, &m2, &m3, &m4, &m5);
   
   aggr= m1+m2+m3+m4+m5;
   per= aggr/5;
   printf("aggregate mark= %d\n", aggr);
   printf("percentage= %f\n", per);
   
  return 0;
}
