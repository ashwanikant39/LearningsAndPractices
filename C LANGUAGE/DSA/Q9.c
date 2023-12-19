// Name: Ashwani Kant   Roll no: 2104939
#include <stdio.h>
#include <stdlib.h>

// Definition of a binary tree node
struct Node {
    int data;
    struct Node *left;
    struct Node *right;
};

// Function to create a new binary tree node
struct Node* createNode(int data) {
    struct Node* newNode = (struct Node*)malloc(sizeof(struct Node));
    newNode->data = data;
    newNode->left = newNode->right = NULL;
    return newNode;
}

// Function to perform preorder traversal
void preorderTraversal(struct Node *root) {
    if (root != NULL) {
        // Process the current node
        printf("%d ", root->data);

        // Recursively traverse the left subtree
        preorderTraversal(root->left);

        // Recursively traverse the right subtree
        preorderTraversal(root->right);
    }
}

int main() {
    // Creating a sample binary tree
    struct Node* root = createNode(1);
    root->left = createNode(2);
    root->right = createNode(3);
    root->left->left = createNode(4);
    root->left->right = createNode(5);

    printf("Preorder Traversal: ");
    preorderTraversal(root);

    return 0;
}