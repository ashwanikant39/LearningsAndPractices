// Program to display ones complement of a given positive binary number

#include <iostream>

using namespace std;

int main()
{
    string m = "";
    string n = "aditya";
    for (int i = 1; i <= n.size() - 1; i++)
    {
        m = m+n[i];
    }
    cout << m;


    // string a="00000001011";
    // for(int i=0; i<=a.size()-1; i++){
    //      cout<<a[i]-'0';
    // }
    // cout<<1%2;
    //     int len, i;
    //     string bin, ones;

    //     cout << "ENTER BINARY NUMBER: ";
    //     cin >> bin;

    //     len = bin.length();
    //     ones.resize(len);

    //     for (i = 0; i < len; i++)
    //     {
    //         if (bin[i] == '0')
    //         {
    //             ones[i] = '1';
    //         }
    //         else
    //         {
    //             ones[i] = '0';
    //         }
    //     }

    //     cout << "\nONE'S COMPLEMENT: " << ones;
    return 0;
}
