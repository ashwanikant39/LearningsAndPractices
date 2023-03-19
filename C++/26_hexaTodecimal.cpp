// #include <iostream>
#include <bits/stdc++.h>
using namespace std;

void octalTodecimal()
{
    string num;
    cout << "Enter your HEXA number: ";
    cin >> num;
    int len = num.size();

    int ans = 0;
    int x = 1;
    int y;
    int rem;
    for (int i = len - 1; i >= 0; i--)
    {
        // cout << num[i];

        if (num[i] >= '0' && num[i] <= '9')
        {
            y = x * (num[i] - 48); //because string 0 ki int value 48 or string 1 ki 49
            ans = ans + y;
        }
        else if (num[i] >= ('A') && num[i] <= ('F'))
        {
            y = x * (num[i] - 55);
            ans = ans + y;
        }
        x = x * 16;
    }
    cout << ans;
}
int main()
{
    // int n = 'F' - 55;
    // cout << n;
    octalTodecimal();

    return 0;
}