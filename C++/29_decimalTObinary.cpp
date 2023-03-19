#include <iostream>
using namespace std;
int main()
{
    int num;
    cout << "Enter decimal number: ";
    cin >> num;

    int rem;
    int ans;
    while (num > 0)
    {
        rem = num % 2;
        cout << rem;
        num = num / 2;
    }

    return 0;
}