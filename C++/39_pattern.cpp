#include <iostream>
using namespace std;
int main()
{
    cout << endl;
    int i = 1;

    while (i <= 5)
    {
        int j = 5;
        while (j >= 1)
        {
            cout << j;
            j--;
        }
        cout << endl;
        i++;
    }
    cout << endl;

    return 0;
}