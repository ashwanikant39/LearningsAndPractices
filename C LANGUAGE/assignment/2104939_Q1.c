// Name: Ashwani Kant
// Roll No: 2104939
// Branch: Voc. IT

#include <stdio.h>
#include <stdlib.h>
#include <ctype.h>

// Function to check if a character is a vowel
int isVowel(char ch) {
    ch = tolower(ch); // Convert character to lowercase
    return (ch == 'a' || ch == 'e' || ch == 'i' || ch == 'o' || ch == 'u');
}

int main() {
    FILE *sourceFile, *destinationFile;
    char sourceFileName[50], destinationFileName[50];
    char ch;

    // Input source file name
    printf("Enter the source file name: ");
    scanf("%s", sourceFileName);

    // Open source file for reading
    sourceFile = fopen(sourceFileName, "r");
    if (sourceFile == NULL) {
        printf("Unable to open file '%s' for reading.\n", sourceFileName);
        exit(EXIT_FAILURE);
    }

    // Input destination file name
    printf("Enter the destination file name: ");
    scanf("%s", destinationFileName);

    // Open destination file for writing
    destinationFile = fopen(destinationFileName, "w");
    if (destinationFile == NULL) {
        printf("Unable to open file '%s' for writing.\n", destinationFileName);
        fclose(sourceFile);
        exit(EXIT_FAILURE);
    }

    // Read from source file, remove vowels, and write to destination file
    while ((ch = fgetc(sourceFile)) != EOF) {
        if (!isVowel(ch)) {
            fputc(ch, destinationFile);
        }
    }

    // Close files
    fclose(sourceFile);
    fclose(destinationFile);


    // Display contents of the destination file
    printf("\nContents of the new file '%s':\n", destinationFileName);
    destinationFile = fopen(destinationFileName, "r");
    if (destinationFile == NULL) {
        printf("Unable to open file '%s' for reading.\n", destinationFileName);
        exit(EXIT_FAILURE);
    }

    while ((ch = fgetc(destinationFile)) != EOF) {
        printf("%c", ch);
    }

    // Close file
    fclose(destinationFile);

    return 0;
}
