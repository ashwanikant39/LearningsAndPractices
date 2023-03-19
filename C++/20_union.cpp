#include <iostream>
using namespace std;

union money
{
    float money;
    int paise;
    char rice;
};

int main()
{
    union money si;
    si.money = 2.00;
    // si.paise = 200;
    cout << si.money;

    return 0;
}