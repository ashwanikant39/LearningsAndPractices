#include <iostream>
using namespace std;
int main()
{
    int num, fact = 1;
    cout << "Enter number for factorial: ";
    cin >> num;
    for (int i = 1; i <= num; i++)
    {
        fact = fact * i;
    }
    cout << fact;
    return 0;
}