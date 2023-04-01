#include <iostream>
using namespace std;
int main()
{

    
    // int investRS;
    // cout << "Enter rupay at first day: ";
    //  cin >> investRS;

    long investRS = 2;
    long days;
    long totalInvest = 0;
    long investPerDay;
   
    cout << "\n\nEnter days: ";
    cin >> days;
    for (int i = 1; i <= days; i++)
    {
        investPerDay = investRS * 3;
        cout << "(" << i << " Day) " << investRS << ", " << investRS << ", " << investRS << "=  " << investPerDay << endl;
        investRS *= 2;
        totalInvest = totalInvest + investPerDay;
    }
    investRS = investRS / 2;
    long profit = investRS * 9 - totalInvest;
    long win = investRS * 9;
    cout << endl
         << "Total invest in " << days << " day= " << totalInvest << endl;
    cout << "Win at " << days << "th day= (" << investRS << "*9)= " << win << endl;
    cout << "Profit in " << days << " days= " << profit << endl;
    cout << "Profit in percentage= " << (profit * 100.0) / totalInvest << "\n\n";

    return 0;
}
