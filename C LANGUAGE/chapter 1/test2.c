#include <stdio.h>

int main() {
    int num1, num2, max;

    // Input two numbers
    printf("Enter the first number: ");
    scanf("%d", &num1);
    printf("Enter the second number: ");
    scanf("%d", &num2);

    // Find the maximum number using the ternary operator
    max = (num1 > num2) ? num1 : num2;

    // Output the maximum number
    printf("The maximum number is: %d\n", max);

    return 0;
}
