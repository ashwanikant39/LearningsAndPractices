//Name: Ashwani Kant     Roll no: 2104939
#include <stdio.h>
#include <stdlib.h>

// Define the structure for a node
struct Node {
    int data;
    struct Node* next;
};

// Function to insert a new node at the beginning
struct Node* insertAtBeginning(struct Node* head, int newData) {
    // Allocate memory for a new node
    struct Node* newNode = (struct Node*)malloc(sizeof(struct Node));

    // Check if memory allocation was successful
    if (newNode == NULL) {
        printf("Memory allocation failed.\n");
        exit(1); // Exit the program with an error code
    }

    // Assign data to the new node
    newNode->data = newData;

    // Set the next of the new node to the current head
    newNode->next = head;

    // Update the head to point to the new node
    head = newNode;

    return head;
}

// Function to print the linked list
void printList(struct Node* head) {
    struct Node* current = head;

    // Traverse the list and print each node's data
    while (current != NULL) {
        printf("%d ", current->data);
        current = current->next;
    }

    printf("\n");
}

int main() {
    // Initialize an empty linked list
    struct Node* head = NULL;

    // Insert nodes at the beginning
    head = insertAtBeginning(head, 3);
    head = insertAtBeginning(head, 7);
    head = insertAtBeginning(head, 1);

    // Print the linked list
    printf("Linked List: ");
    printList(head);

    return 0;
}