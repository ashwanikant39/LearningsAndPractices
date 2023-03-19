#include <iostream>
using namespace std;

int main()
{
    int n;
    cout << "Enter the binary number: ";
    cin >> n;

    int ans = 0;
    int rem;
    int x = 1;
    int y;
    while (n > 0)
    {
        rem = n % 10;
        y = rem * x;
        ans = ans + y;
        x = x * 2;
        n = n / 10;
    }
    cout << ans;

    // cout << binaryTOdecimal(n) << endl;

    return 0;
}
