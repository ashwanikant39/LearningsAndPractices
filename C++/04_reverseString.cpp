#include <iostream>
#include <cstring>
using namespace std;
int main()
{
    char name[50];

    cout << "Enter your string: ";
    fgets(name, 50, stdin);
    
    strrev(name);
    cout << name;

    return 0;
}