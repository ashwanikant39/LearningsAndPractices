#include <iostream>
using namespace std;
int main()
{
    int d1, d2, d3, d4, d5;
    int mainNum;
    cout << "Enter number to check: ";
    cin >> mainNum;

    int num = mainNum; // give original value to num

    d1 = mainNum % 10;      // last fisrt digit
    mainNum = mainNum / 10; // delete last first dogit
    d2 = mainNum % 10;      // last second digit
    mainNum = mainNum / 10; // delete last second digit
    d3 = mainNum % 10;      // last third digit
    mainNum = mainNum / 10; // delete last third digit
    d4 = mainNum % 10;      // last fourth digit
    mainNum = mainNum / 10; // delete last fourth digit
    d5 = mainNum % 10;      // last fifth digit
    int reverse = 10000 * d1 + 1000 * d2 + 100 * d3 + 10 * d4 + d5;

    cout << "After reverse= " << reverse << "\n";

    if (num == reverse)  //compare
    {
        cout << "Number is palindrome";
    }
    else
    {
        cout << "Number is not palindrome";
    }
    return 0;
}
