#include <iostream>
using namespace std;

int fun(int a, float b)
{
    float x;
    x = a + b;
    return x;
}

int main()
{
    int a;
    float b;
    a = 2;
    b = 2.5;
    cout << fun(a, b);
    // cout << n;
}