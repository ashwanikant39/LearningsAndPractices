#include <stdio.h>
increment(){
    static int i=1;
    printf("%d\n",i);
    i=i+1;
}

int main() {


//     int a=10,b=20;
//     swapr(&a, &b);
//     printf("\na=%d b=%d",a,b);

// swapr(int *x, int *y){
//     int t;
//     t=*x;
//     *x=*y;
//     *y=t;
// }
increment();
increment();
increment();


    return 0;
}
