#include <iostream>
using namespace std;
int main()
{
    int n;
    cout << "Enter num: ";
    cin >> n;
    int a = 0, b = 1, c;
    for (int i = 0; i <= n; i++)
    {

        c = a + b;
        cout << c << " ";
        a = b;
        b = c;
    }

    return 0;
}