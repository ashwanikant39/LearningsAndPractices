#include <iostream>
using namespace std;
int c = 20;
int main()
{

    int a = 5;
    int b = 6;
    int c = a + b;
    cout << c << endl;
    cout << ::c << endl;
    
    return 0;
}