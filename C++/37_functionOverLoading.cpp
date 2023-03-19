#include <iostream>
using namespace std;

int sum(int a, int b)
{
    return a + b;
}

int sum(int a, int b, int c)

{
    return a + b + c;
}

int main()
{
    cout << "the sum of 4 and 5 is " << sum(4, 5) << endl;

    cout << "the sum of 4, 3 and 5 is " << sum(4, 3, 5) << endl;

    return 0;
}
