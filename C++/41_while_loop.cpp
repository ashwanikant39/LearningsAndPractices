#include <iostream>
using namespace std;
int main()
{
    int num;
    cout << "Enter number for table: ";
    cin >> num;
    int i = 1;
    while (i <= 10)
    {
        cout<<num<<"*"<<i<<"= "<< num*i<<endl;
        i++;
        // printf("%d*%d=%d\n", num,i,num*i);
        // i++;
    }
    return 0;
}
