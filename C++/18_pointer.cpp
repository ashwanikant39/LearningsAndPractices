#include <iostream>
using namespace std;
int main()
{
    //   ---pointer---

    int a = 5;
    int *b = &a;
    cout << "The address of a is: " << &a << endl;
    cout << "The address of a is: " << b << endl;
    cout << "The value at b is: " << *b << endl;

    //  --- Pointer to pointer---

    int **c = &b;
    cout << "The address of b is: " << c << endl;
    cout << "The address of b is: " << &b << endl;
    cout << "The value at c is: " << **c << endl;


    return 0;
}