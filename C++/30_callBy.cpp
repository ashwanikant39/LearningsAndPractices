#include <iostream>
using namespace std;

void swapPointer(int *a, int *b)
{
    int tem = *a;
    *a = *b;
    *b = tem;
}

int main()
{
    int a = 4, b = 5;
    cout << "The value of a is: " << a << " \nThe value of b is : " << b << endl;
    cout << "---After call by reference---" << endl;
    swapPointer(&a, &b);
    cout << "The value of a is: " << a << " \nThe value of b is : " << b << endl;

    return 0;
}