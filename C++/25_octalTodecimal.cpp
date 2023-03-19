#include <iostream>
using namespace std;

int octalTodecimal(int num)
{
    int ans = 0;
    int x = 1;
    int y;
    int rem;

    while (num > 0)
    {
        rem = num % 10;
        y = rem * x;
        ans = ans + y;
        x = x * 8;
        num = num / 10;
    }
    cout << ans;
}
int main()
{
    int num;
    cout << "Enter your OCTAL number: ";
    cin >> num;
    octalTodecimal(num);

    return 0;
}
