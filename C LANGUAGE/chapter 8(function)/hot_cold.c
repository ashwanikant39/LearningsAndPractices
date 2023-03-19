#include <stdio.h>
float temperature(float);

int main()
{
    float tem;
    printf("Enter the temperature: ");
    scanf("%f", &tem);

    temperature(tem);

    return 0;
}
float temperature(float tem)
{
    if (tem > 25)
        printf("HOT");
    else
        printf("COOL");
}
