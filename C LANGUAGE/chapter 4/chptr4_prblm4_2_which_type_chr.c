#include<stdio.h>
int main(){
    char ch;
    printf("enter the character: ");
    scanf("%c", &ch);

    if('A'<=ch && ch<='Z')
        printf("character is a capital letter");
    else if('a'<=ch && ch<='z')
        printf("character is a small case letter");
    else if('0'<=ch && ch<='9')
        printf("character is a digit");
    else{
        printf("character is a special symbol");
    }
    
  



    return 0;
}