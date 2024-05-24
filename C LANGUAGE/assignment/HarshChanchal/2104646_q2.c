// Name - Harsh Chanchal 
// Roll no - 2104646 
// Branch - Electrical (3rd year)


#include <stdio.h>
#include <string.h>

#define MAX_NAMES 5
#define MAX_LENGTH 20

int main() {
    char names[MAX_NAMES][MAX_LENGTH];
    char prefix[MAX_LENGTH];
    int i;

    // Input prefix
    printf("Enter the prefix: ");
    fgets(prefix, MAX_LENGTH, stdin);

    // Remove newline character from prefix
    prefix[strcspn(prefix, "\n")] = '\0';

    // Input names
    printf("Enter %d names:\n", MAX_NAMES);
    for (i = 0; i < MAX_NAMES; i++) {
        printf("Name %d: ", i + 1);
        fgets(names[i], MAX_LENGTH, stdin);

        // Remove newline character from name
        names[i][strcspn(names[i], "\n")] = '\0';

        // Insert prefix at the beginning of the name
        memmove(names[i] + strlen(prefix), names[i], strlen(names[i]) + 1); // Shift the name to make space for prefix
        memcpy(names[i], prefix, strlen(prefix)); // Insert prefix
    }

    // Display modified names
    printf("\nModified names:\n");
    for (i = 0; i < MAX_NAMES; i++) {
        printf("%s\n", names[i]);
    }

    return 0;
}
