#include<stdio.h>
int main()
{
    int lenght, hight, A1_lenght, A1_hight, A2_lenght, A2_hight, A3_lenght, A3_hight, A4_lenght, A4_hight, A5_lenght, A5_hight, A6_lenght, A6_hight, A7_lenght, A7_hight, A8_lenght, A8_hight;
    printf("enter dimensions of A0:");
    scanf("%d %d", &lenght, &hight);
    
    A1_lenght= hight;
    A1_hight= lenght/2;
    
    A2_lenght= A1_hight;
    A2_hight= A1_lenght/2;
    
    A3_lenght= A2_hight;
    A3_hight= A2_lenght/2;
    
    A4_lenght= A3_hight;
    A4_hight= A3_lenght/2;
    
    A5_lenght= A4_hight;
    A5_hight= A4_lenght/2;
    
    A6_lenght= A5_hight;
    A6_hight= A5_lenght/2;
    
    A7_lenght= A6_hight;
    A7_hight= A6_lenght/2;
    
    A8_lenght= A7_hight;
    A8_hight= A7_lenght/2;
    
    
    printf("dimensions of A1=%dmm * %dmm\n", A1_lenght, A1_hight);
    printf("dimensions of A2=%dmm * %dmm\n", A2_lenght, A2_hight);
    printf("dimensions of A3=%dmm * %dmm\n", A3_lenght, A3_hight);
    printf("dimensions of A4=%dmm * %dmm\n", A4_lenght, A4_hight);
    printf("dimensions of A5=%dmm * %dmm\n", A5_lenght, A5_hight);
    printf("dimensions of A6=%dmm * %dmm\n", A6_lenght, A6_hight);
    printf("dimensions of A7=%dmm * %dmm\n", A7_lenght, A7_hight);
    printf("dimensions of A8=%dmm * %dmm\n", A8_lenght, A8_hight);
    
    return 0;
    
    
}
