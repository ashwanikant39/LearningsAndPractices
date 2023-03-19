#include <stdio.h>
int countvowels(char arr[]);
int countLenght(char arr[]);
int main()
{
    char name[100];
    printf("Enter the sentence: ");
    fgets(name, 100, stdin);

    // countvowels(name);
    // countconst(name);
    int x = countvowels(name);
    printf("vowels are %d\n", x);
    int y = countLenght(name);
    printf("lenght is %d\n", y);
    int z = y - x;   //total lenght - vowels
    printf("consonants are %d", z);
    return 0;
}
int countvowels(char arr[])
{
    int count = 0;
    for (int i = 0; arr[i] != '\0'; i++)
    {
        if (arr[i] == 'a' || arr[i] == 'e' || arr[i] == 'i' || arr[i] == 'o' || arr[i] == 'u') // FOR COUNT vowel
            count++;
    }
    return count; // return vowels
}

int countLenght(char arr[])
{
    int count = 0;
    for (int i = 0; arr[i] != '\0'; i++)
    {
        count++;
    }
    return count - 1; // FOR COUNT LENGHT
}
