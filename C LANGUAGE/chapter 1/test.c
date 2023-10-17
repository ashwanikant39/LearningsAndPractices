#include<stdio.h>

int main()
{
    int lenght ;
    int width ; 


    printf(" Eneter the perimeter lenght: ");
    scanf("%d",&lenght);

// printf("%d", lenght);
    printf(" Eneter the perimeter width: ");
    scanf("%d",&width);


    printf(" perimeter of rectangle  : %d " , 2 * (lenght + width) );

    return 0 ;

}