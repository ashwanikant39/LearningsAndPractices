
#include <stdio.h>
#include <stdlib.h>
#include <time.h>

int main()
{
    int number, guess, nguesses = 1;
    srand(time(0));
    number = rand() % 100 + 1;
    printf("%d", number);
     printf("\nguess the num b/t 1 to 100: ");

    do
    {
       
        scanf("%d", &guess);
        if (guess > number)
        {
            printf("please enter a lower number please\n");
        }
        else if (guess < number)
        {
            printf("please enter a higher number please\n");
        }
        else
        {
            printf("\nyou guesses it in %d attempts\n", nguesses);
        }
        nguesses++;

    } while (guess != number);
    return 0;
}