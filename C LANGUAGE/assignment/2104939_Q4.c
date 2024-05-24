// Name: Ashwani Kant
// Roll No: 2104939
// Branch: Voc. IT

#include <stdio.h>
#include <string.h>

// Function to convert a string to plural form
void makePlural(char *word) {
    int length = strlen(word);

    // Check if the word ends with 'y' and is not a vowel sound
    if (word[length - 1] == 'y' && !(word[length - 2] == 'a' || word[length - 2] == 'e' || word[length - 2] == 'i' || word[length - 2] == 'o' || word[length - 2] == 'u')) {
        strcpy(word + length - 1, "ies"); // Replace 'y' with 'ies'
    } else {
        strcat(word, "s"); // Add 's' for plural form
    }
}

int main() {
    char animal[20], bird[20];

    // Input the name of an animal and a bird
    printf("Enter the name of an animal: ");
    scanf("%s", animal);
    printf("Enter the name of a bird: ");
    scanf("%s", bird);

    // Make plural forms of animal and bird names
    makePlural(animal);
    makePlural(bird);

    // Display plural forms of animal and bird names
    printf("\nPlural form of %s: %s\n", animal, animal);
    printf("Plural form of %s: %s\n", bird, bird);

    return 0;
}
