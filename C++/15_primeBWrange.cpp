#include <iostream>
using namespace std;

void printPrime(int num1, int num2)
{
    for (int i = num1; i <= num2; i++)
    {
        int j;
        for (j = 2; j < i; j++)
        {
            if (i % j == 0)
                break;
        }
        if (i == j)
        {
            cout << i << " ";
        }
    }
}

int main()
{

    int num1, num2;
    cout << "Enter starting number: ";
    cin >> num1;
    cout << "Enter ending number: ";
    cin >> num2;

    printPrime(num1, num2);

    return 0;
}