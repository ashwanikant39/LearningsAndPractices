// Name:Ashwani Kant    ROll n:2104939
#include <stdio.h>
#include <stdlib.h>
#define MAX_SIZE 10
// Structure to represent a stack
struct Stack {
    int arr[MAX_SIZE];
    int top;
};
// Function to initialize the stack
void initialize(struct Stack *stack) {
    stack->top = -1;
}
// Function to check if the stack is full
int isFull(struct Stack *stack) {
    return stack->top == MAX_SIZE - 1;
}
// Function to push an element onto the stack
void push(struct Stack *stack, int value) {
    if (isFull(stack)) {
        printf("Stack overflow! Cannot push %d\n", value);
        return;
    }
    stack->arr[++stack->top] = value;
    printf("%d pushed to the stack\n", value);
}
// Function to print the elements of the stack
void printStack(struct Stack *stack) {
    printf("Stack: ");
    for (int i = 0; i <= stack->top; ++i) {
        printf("%d ", stack->arr[i]);
    }
    printf("\n");
}
// Main function to test the stack implementation
int main() {
    struct Stack myStack;
    initialize(&myStack);
     push(&myStack, 5);
    push(&myStack, 10);
    push(&myStack, 15);
    printStack(&myStack);
    return 0;
}