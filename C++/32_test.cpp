
#include <iostream>

using namespace std;

int main()
{
    int len, i;
    string bin, ones;

    cout << "ENTER BINARY NUMBER: ";
    cin >> bin;

    len = bin.length();
    ones.resize(len);

    for (i = 0; i < len; i++)
    {
        if (bin[i] == '0')
        {
            ones[i] = '1';
        }
        else
        {
            ones[i] = '0';
        }
    }

    cout << "\nONE'S COMPLEMENT: " << ones;
    
    return 0;
}