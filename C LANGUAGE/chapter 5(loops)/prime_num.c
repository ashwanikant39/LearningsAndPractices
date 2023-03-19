#include<stdio.h>
int main(){
    int num, i;
for(num=1; num<=100; num++)
{
    
    for(i=2; i<num; i++)
    { 
       if(num%i==0)
       break;
      }
      if(i==num)
      printf("%d\t", num);
}


    return 0;
}