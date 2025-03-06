#include <stdio.h>
int main()
{
    int num, D1, D2, D3, D4, D5;
    long int reverse;
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

    reverse = D1 * 10000 + D2 * 1000 + D3 * 100 + D4 * 10 + D5;
    printf("sum of digit is= %ld", reverse);
}