#include<stdio.h>
int main(){

    float otpay;
    int hour, i=1;
    while(i<=10){
        printf("enter the hours: ");
        scanf("%d", &hour);

        if(hour>=40)
              otpay= (hour-40)*120;
        else
              otpay= 0;
            
printf("hour= %d overtimepay= Rs. %f\n", hour, otpay);
i++;

    }
    return 0;
}