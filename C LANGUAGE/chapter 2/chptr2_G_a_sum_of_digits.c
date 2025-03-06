#include <stdio.h>
int main()
{
    int num, D1, D2, D3, D4, D5, sum_of_digits;
    printf("enter tha five digit number:");
    scanf("%d", &num); // 65485

    D1 = num % 10;  // first digit:5
    num = num / 10; // 6548 remainng digit
    D2 = num % 10;  // second digit:8
    num = num / 10; // 654remainng digit
    D3 = num % 10;  // third digit:4
    num = num / 10; // 65 remainng digit
    D4 = num % 10;  // fourth digit:5
    num = num / 10; // 6 remaining digit
    D5 = num % 10;  // fifth digit: 6

    sum_of_digits = D1 + D2 + D3 + D4 + D5;
    printf("sum of digit is= %d", sum_of_digits);
}