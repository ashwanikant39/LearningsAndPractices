#include <stdio.h>
#include <stdlib.h>
#include <time.h>

int main()
{
    int number;
    srand(time(0));
    number = rand() % 10;
    printf("\nthe random number is: %d\n\n", number);
    return 0;
}
