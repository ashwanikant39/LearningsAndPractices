#include<stdio.h>
int main(){
    int age;
    char ms, sex;
    printf("enter the age, ms, sex:");
    scanf(" %d %c %c", &age, &ms, &sex);

    if((ms=='Y') || (ms=='N' && sex=='M' && age>30) ||   (ms=='N' && sex=='F' && age>25)) {
        printf("Yes");

    } else{
        printf("No");
    }                                                   
    
    return 0;
}