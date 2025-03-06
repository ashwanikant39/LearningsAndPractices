// check number prime or not

#include <iostream>
using namespace std;
int main()
{
    int num, i;
    int prime = 1;
    cout << "Enter number for check: ";
    cin >> num;
    for (int i = 2; i < num; i++)
    {
        if (num % i == 0)
        {
            prime = 0;
            break;
        }
    }
    if (prime)
    {
        cout << "Number is prime";
    }
    else
    {
        cout << "number is not prime";
    }

    return 0;
}