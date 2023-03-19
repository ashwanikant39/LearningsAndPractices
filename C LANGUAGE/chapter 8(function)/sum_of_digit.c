#include<stdio.h>
int sum(int);

int main(){
    int num;
    printf("Enter the number: ");
    scanf("%d", &num);

   
int t= sum(num);
printf("total sum of digits is %d", t);

    return 0;
}
int sum(int num){
 int D1, D2, D3;
 D1= num%10;
 num= num/10;
 D2= num%10;
 num= num/10;
 D3=num%10;
 int tsum= D1+D2+D3;
 return tsum;

}
 