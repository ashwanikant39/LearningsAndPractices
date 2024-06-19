#include <stdio.h>
#include <stdlib.h>
#include <math.h>
int main()
{

    printf("\n\n  (CALCULATOR  \n\n");

    int choice, num, fact, i;
    float a, b;
    int x, y;

    // while (1)
    // {
        printf("1. for factorial\n");
        printf("2. for prime\n");
        printf("3. for odd or even\n");
        printf("4. for Addition\n");
        printf("5. for substraction\n");
        printf("6. for multiply\n");
        printf("7. for divide\n");
        printf("8. for remainder\n");
        printf("9. for squar\n");
        printf("10. for root\n");
        printf("11. for cube\n");
        printf("12. for exit\n\n");

        printf("Enter your choice?\n");
        scanf("%d", &choice);
        switch (choice)
        {

        case 1:

            printf("enter the number for factorial: ");
            scanf("%d", &num);
            fact = 1;
            for (i = 1; i <= num; i++)
                fact = fact * i;

            printf("factorial of %d is %d\n\n", num, fact);
            break;

        case 2:
            printf("enter the number for cheking prime or not: ");
            scanf("%d", &num);

            for (i = 2; i < num; i++)
            {
                if (num % i == 0)
                {
                    printf("%d is Not a prime number\n\n", num);
                    break;
                }
            }
            if (i == num)
                printf("%d is a prime number\n\n", num);

            break;
        case 3:
            printf("enter the num: ");
            scanf("%d", &num);
            if (num % 2 == 0)
                printf("%d is even\n\n", num);
            else
                printf("%d is odd\n\n", num);
            break;

        case 4:
            printf("enter two num for add: ");
            scanf("%f %f", &a, &b);

            printf("addition of %f & %f is= %f\n\n", a, b, a + b);
            break;

        case 5:
            printf("enter two num for sub: ");
            scanf("%f %f", &a, &b);

            printf("sub= %f\n\n", a - b);
            break;

        case 6:
            printf("Enter the num for multiple: ");
            scanf("%f %f", &a, &b);

            printf("multyply= %f\n\n", a * b);
            break;

        case 7:
            printf("Enter num for devide: ");
            scanf("%f %f", &a, &b);
            printf("Answer= %f\n\n", a / b);
            break;

        case 8:
            printf("Enter two number for remainder: ");
            scanf("%d %d", &x, &y);
            printf("Remainder is= %d\n\n", x % y);
            break;
        case 9:
            printf("Enter number for Square: ");
            scanf("%f", &a);
            printf(" Square is= %f\n\n", a * a);
            break;
        case 10:
            printf("Enter number for root: ");
            scanf("%f", &a);
            float s = sqrt(a);
            printf("%f\n\n", s);
            break;
        case 11:
            printf("Enter the number for cube root: ");
            scanf("%f", &a);
            float c = cbrt(a);
            printf("Cube root is= %f\n\n", c);
            break;

        case 12:
            exit(0);
        default:
            printf("wronge choice\n");
        }
    // }
    return 0;
}