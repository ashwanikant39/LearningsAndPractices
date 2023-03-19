#include<stdio.h>
int main(){
float ang_1, ang_2, ang_3;

printf("enter first angle: ");
scanf("%f", &ang_1);
printf("enter second angle: ");
scanf("%f", &ang_2);
printf("enter third angle: ");
scanf("%f", &ang_3);

if(ang_1+ang_2+ang_3==180.00){
    printf("tringle is valid");

}else{
    printf("tringle is not valid");
}



    return 0;
}