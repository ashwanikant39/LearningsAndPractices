#include <stdio.h>

int main() {
    int C, D, temp;

    // Input two numbers C and D
    printf("Enter the value of C: ");
    scanf("%d", &C);
    printf("Enter the value of D: ");
    scanf("%d", &D);

    // Interchange the contents of C and D using a temporary variable
    temp = C;
    C = D;
    D = temp;

    // Output the new values of C and D
    printf("After interchange:\n");
    printf("Value of C: %d\n", C);
    printf("Value of D: %d\n", D);

    return 0;
}
