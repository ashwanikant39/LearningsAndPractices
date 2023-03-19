#include<stdio.h>
#include<math.h>
int root(int);

int main(){
    int num;
    printf("Enter the number: ");
    scanf("%d", &num);

float ans= root(num);
printf("square root of %d is %f", num, ans);
    return 0;
}

int root(int num){
    double ans= sqrt(num);
    return ans;

}