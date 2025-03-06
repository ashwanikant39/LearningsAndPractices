#include <iostream>
using namespace std;

int sum(int a, int b, int c = 10)
{
    return a + b + c;
}

int main()
{
    int a = 2, b = 3, c = 4;
    cout << "The value of sum is: " << sum(a, b, c) << endl; // normaly
    cout << "The value of sum is: " << sum(a, b) << endl;    // with default argument

    return 0;
}