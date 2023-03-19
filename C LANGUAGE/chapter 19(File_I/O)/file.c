#include<stdio.h>
int main(){
    FILE *fptr;
    fptr = fopen("file.txt", "r");
    fclose(fptr);




    return 0;
}