// Square of any number using logic

#include <iostream>
using namespace std;
int main()
{
    int num1, num2;
    cout << "Enter any number for power: ";
    cin >> num1;
    cout << "Enter (to the power) for this number: ";
    cin >> num2;

    int ans = 1;

    for (int i = 1; i <= num2; i++)
    {
        ans = num1 * ans;
    }
    cout << ans;

    return 0;
}