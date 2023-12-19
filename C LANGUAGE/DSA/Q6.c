// Name: Ashwani Kant    Roll no:2104939
#include <stdio.h>
#include <stdlib.h>

#define MAX_SIZE 100

// Define the structure for a queue
struct Queue {
    int front, rear;
    int arr[MAX_SIZE];
};

// Function to enqueue an element into the queue
void enqueue(struct Queue* queue, int data) {
    // Check if the queue is full
    if (queue->rear == MAX_SIZE - 1) {
        printf("Queue is full. Cannot enqueue.\n");
        return;
    }

    // Increment rear and add the new element to the queue
    queue->arr[++queue->rear] = data;

    // If it's the first element, update front as well
    if (queue->front == -1) {
        queue->front = 0;
    }

    printf("%d enqueued to the queue.\n", data);
}

int main() {
    // Initialize a queue
    struct Queue queue;
    queue.front = queue.rear = -1; // Initialize front and rear

    // Enqueue elements
    enqueue(&queue, 10);
    enqueue(&queue, 20);
    enqueue(&queue, 30);

    return 0;
}