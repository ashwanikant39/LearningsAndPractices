#include <iostream>
using namespace std;
int main()
{
    int a, b, c;
    cout << "Enter three value-- A, B, C: ";
    cin >> a >> b >> c;

    int A = a * a;
    int B = b * b;
    int C = c * c;

    if (a > b && a > c)
    {
        if (A == B + C)
        {
            cout << "YES";
        }
        else
        {
            cout << "NO";
        }
    }
    else if (b > a && b > c)
    {
        if (B == A + C)
        {
            cout << "YES";
        }
        else
        {
            cout << "NO";
        }
    }
    else
    {
        if (C == A + B)
        {
            cout << "YES";
        }
        else
        {
            cout << "NO";
        }
    }
    return 0;
}
