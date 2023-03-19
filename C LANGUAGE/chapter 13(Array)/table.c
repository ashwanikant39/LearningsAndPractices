#include<stdio.h>
int main(){
    int n;
    int mul[10];;
    printf("Enter the num for table: ");
    scanf("%d", &n);
printf("\n");
    for(int i=0; i<10; i++){
        mul[i]= n*(i+1);
    }
 for(int i=0; i<10; i++){
    printf("%d*%d = %d\n",n,  i+1, mul[i]);
  
 }
  printf("\n");

    return 0;
}