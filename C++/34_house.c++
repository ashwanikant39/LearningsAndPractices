// Online C++ compiler to run C++ program online
#include <iostream>
using namespace std;

int main()
{
    // Write C++ code here
    // std::cout << "Hello world!";
    int n = 6;
    int i, j;
    for (i = 1; i <= n - 1; i++)
    {

        for (j = 1; j <= n; j++)
        {
            if (j == (n + 1) - i)
            {
                cout << "*";
            }
            else
            {
                cout << " ";
            }
        }
        for (int k = 2; k <= i; k++)
        {
            if (k == i)
            {
                cout << "*";
            }
            else
            {
                cout << " ";
            }
        }
        cout << endl;
    }
    for (i = 1; i <= n; i++)
    {
        for (j = 1; j <= 2 * n - 1; j++)
        {
            if (i == 3 && j != 2 && j != 3 && j != 9 && j != 10 || i == n || j == 1 || j == 2 * n - 1 || (j == 4 || j == 8) & (i != 1 && i != 2))
            {
                cout << "*";
            }
            else
            {
                cout << " ";
            }
        }
        cout << endl;
    }

    return 0;
}

