#include <iostream>
#include<iomanip>
using namespace std;
int main()
{
    int a = 3, b = 12, c = 1234;
    cout << a << endl;
    cout << b << endl;
    cout << c << endl;
cout<<"After manipulat\n";
    cout << setw(4) << a << endl;
    cout << setw(4) << b << endl;
    cout << setw(5) << c << endl;
    return 0;
}