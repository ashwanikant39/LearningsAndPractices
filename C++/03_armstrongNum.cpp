#include <iostream>
using namespace std;
int main()
{
    int num, rem, remCube = 0;
    cout << "Enter your num: ";
    cin >> num;
    int fNum = num;

    while (num != 0)
    {
        rem = num % 10;

        remCube = remCube + (rem * rem * rem);

        num = num / 10;
    }
    if (fNum == remCube)
    {
        cout << "Your number is Armstrong";
    }
    else
    {
        cout << "Your number is not Armstrong";
    }

    return 0;
}