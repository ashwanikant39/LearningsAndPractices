#include<stdio.h>
#include<math.h>

int main(){
float x, y, r, pi, theta;

  pi=3.14;
printf("enter cartesinates(x,y)\n");
scanf("%f %f", &x, &y);

r= sqrt(x*x+y*y);
theta= atan(y/x);  //radian

theta= theta*(180.0/pi);  //radian to degree

printf("polar co-ordinates(r,theata): %f, %f", r, theta);

return 0;
}